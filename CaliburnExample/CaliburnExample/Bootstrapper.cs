using Caliburn.Micro;
using CaliburnExample.FlashMessages;
using CaliburnExample.Services.ViewModelResolver;
using CaliburnExample.Validation;
using CaliburnExample.Views;
using CaliburnExample.Views.HelloWorld;
using CaliburnExample.Views.Main;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CaliburnExample
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container;


        public Bootstrapper()
        {
            Initialize();
        }


        protected override void Configure()
        {
            _container = new SimpleContainer();

            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<IEventAggregator, Caliburn.Micro.EventAggregator>();

            _container.Singleton<IViewModelResolver<IViewModel>, ViewModelResolver>();


            // default window definition
            _container.Singleton<MainViewModel>();


            // View Model definitions
            _container.Singleton<HelloWorldViewModel>(nameof(HelloWorldViewModel));


            // services
            _container.PerRequest<IValidationObject, ValidationObject>();
            _container.Singleton<IFlashMessagesManager, FlashMessagesManager>();


            _container.Instance(_container);
        }


        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            MainViewModel mvm = _container.GetInstance<MainViewModel>();
            _container.BuildUp(mvm);

            _container.GetInstance<IWindowManager>().ShowWindow(mvm);
        }


        protected override void OnExit(object sender, EventArgs e)
        {
        }


        protected override object GetInstance(System.Type service, string key)
        {
            return _container.GetInstance(service, key);
        }


        protected override IEnumerable<object> GetAllInstances(System.Type service)
        {
            return _container.GetAllInstances(service);
        }


        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

    }
}
