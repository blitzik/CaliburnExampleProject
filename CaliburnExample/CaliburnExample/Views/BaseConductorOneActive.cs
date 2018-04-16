using Caliburn.Micro;
using CaliburnExample.Services.ViewModelResolver;
using CaliburnExample.Validation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CaliburnExample.Views
{
    public abstract class BaseConductorOneActive : Conductor<IViewModel>.Collection.OneActive, IViewModel, INotifyDataErrorInfo
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


        public void DisplayView(string viewModelName)
        {
            ActivateItem(GetViewModel(viewModelName));
        }


        private IViewModel GetViewModel(string viewModelName)
        {
            IViewModel viewModel = _viewModelResolver.Resolve(viewModelName);
            if (viewModel == null) {
                throw new Exception("Requested ViewModel does not Exist!");
            }

            return viewModel;
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
