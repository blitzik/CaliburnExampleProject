using Caliburn.Micro;
using CaliburnExample.Services.ViewModelResolver;
using CaliburnExample.Validation;
using CaliburnExample.Views;
using CaliburnExample.Views.Login;
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
            _container.Singleton<LoginViewModel>(nameof(LoginViewModel));


            // services
            _container.PerRequest<IValidationObject, ValidationObject>();


            _container.Instance(_container);
        }


        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            LoginViewModel loginViewModel = _container.GetInstance<LoginViewModel>();
            _container.BuildUp(loginViewModel);

            loginViewModel.OnSuccessfullLogin += (object s, EventArgs args) =>
            {
                MainViewModel mvm = _container.GetInstance<MainViewModel>();
                _container.BuildUp(mvm);

                _container.GetInstance<IWindowManager>().ShowWindow(mvm);
                loginViewModel.TryClose();
            };

            _container.GetInstance<IWindowManager>().ShowWindow(loginViewModel);
        }


        protected override void OnExit(object sender, EventArgs e)
        {
        }


        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }


        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }


        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

    }
}
