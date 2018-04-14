﻿using Caliburn.Micro;
using CaliburnExample.Services.ViewModelResolver;
using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CaliburnExample.Validation;

namespace CaliburnExample.Views
{
    public abstract class BaseConductorAllActive : Conductor<IViewModel>.Collection.AllActive, IViewModel, INotifyDataErrorInfo
    {
        // property injection
        private IEventAggregator _eventAggregator;
        public IEventAggregator EventAggregator
        {
            get { return _eventAggregator; }
            set { _eventAggregator = value; }
        }


        // property injection
        private IViewModelResolver<IViewModel> _viewModelResolver;
        public IViewModelResolver<IViewModel> ViewModelResolver
        {
            get { return _viewModelResolver; }
            set { _viewModelResolver = value; }
        }
       

        protected IViewModel AddViewModel(string viewModelName)
        {
            IViewModel vm = GetViewModel(viewModelName);
            Items.Add(vm);

            return vm;
        }


        protected IViewModel GetViewModel(string viewModelName)
        {
            IViewModel vm = ViewModelResolver.Resolve(viewModelName);
            if (vm == null) {
                throw new Exception("Requested ViewModel does not Exist!");
            }

            return vm;
        }


        // ----- INotifyDataErrorInfo


        // property injection
        private IValidationObject _validation;
        public IValidationObject Validation
        {
            get { return _validation; }
            set { _validation = value; }
        }


        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public void RaiseErrorsChanged(string propertyName)
        {
            Validation.RaiseErrorsChanged(propertyName);
        }


        public bool HasErrors
        {
            get { return Validation.HasErrors; }
        }


        public IEnumerable GetErrors(string propertyName)
        {
            return Validation.GetErrors(propertyName);
        }


        protected void AddMessage(string errorMessage, Severity severity = Severity.ERROR, [CallerMemberName] string propertyName = null)
        {
            Validation.AddMessage(propertyName, errorMessage, severity);
        }


        protected void ClearMessages([CallerMemberName] string propertyName = null)
        {
            Validation.ClearMessages(propertyName);
        }
    }
}
