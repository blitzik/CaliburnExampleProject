using Caliburn.Micro;
using prjt.FlashMessages;
using prjt.Services.ViewModelResolver;
using prjt.Validation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace prjt.ViewModels.Base
{
    public abstract class BaseScreen : Screen, IViewModel, INotifyDataErrorInfo
    {
        // property injection
        private IEventAggregator _eventAggregator;
        public IEventAggregator EventAggregator
        {
            get { return _eventAggregator; }
            set { _eventAggregator = value; }
        }


        // property injection
        private IFlashMessagesManager _flashMessagesManager;
        public IFlashMessagesManager FlashMessagesManager
        {
            get { return _flashMessagesManager; }
            set { _flashMessagesManager = value; }
        }


        protected void FlashMessage(string message, FlashMessages.Type type)
        {
            FlashMessagesManager.DisplayFlashMessage(message, type);
        }


        protected void FlashMessages(FlashMessagesCollection flashMessages)
        {
            FlashMessagesManager.DisplayFlashMessages(flashMessages);
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
