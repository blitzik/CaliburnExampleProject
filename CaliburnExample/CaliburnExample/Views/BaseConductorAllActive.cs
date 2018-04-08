using Caliburn.Micro;
using CaliburnExample.Services.ViewModelResolver;
using System;

namespace CaliburnExample.Views
{
    public abstract class BaseConductorAllActive : Conductor<IViewModel>.Collection.AllActive, IViewModel
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


        public BaseConductorAllActive()
        {
            
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

    }
}
