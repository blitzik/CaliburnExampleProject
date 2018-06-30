using Caliburn.Micro;
using Project.ViewModels;
using Project.Validation;
using Project.FlashMessages;
using Project.Services.ViewModelResolver;
using Project.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Reflection;
using intf.Views;

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
            var config = new TypeMappingConfiguration()
            {
                DefaultSubNamespaceForViews = "intf.Views",
                DefaultSubNamespaceForViewModels = "Project.ViewModels"
            };
            ViewLocator.ConfigureTypeMappings(config);
            ViewModelLocator.ConfigureTypeMappings(config);


            // -----


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


        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            IList<Assembly> assemblies = new List<Assembly>
            {
                GetType().Assembly,
                typeof(MainView).GetTypeInfo().Assembly
            };

            return assemblies;
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
