using Caliburn.Micro;
using CaliburnExample.Views;
using CaliburnExample.Views.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CaliburnExample.Services.ViewModelResolver;
using CaliburnExample.Views.FirstView;
using CaliburnExample.Views.SecondView;

namespace CaliburnExample
{
    public class Bootstrapper : BootstrapperBase
    {
        /*
         * Rovnou využijeme DI kontejner, který framework poskytuje
         */
        private SimpleContainer _container;


        public Bootstrapper()
        {
            // V konstruktoru musí být zavolána tato metoda, protože se v ní inicializuje framework
            Initialize();
        }


        // BootstrapperBase obsahuje více metod, které lze přetížit, nicméně
        // tyhle základní pro začátek bohatě postačí


        // Zde probíhá základní nastavení frameworku a DI kontejneru
        protected override void Configure()
        {
            _container = new SimpleContainer();

            // Pokud registrujeme objekt přes metodu Singleton(), tak se při každém
            // požadavku na tento objekt vrátí vždy stejná instance
            // (jedna instance pro celou aplikaci)
            _container.Singleton<IWindowManager, WindowManager>(); // správa oken
            _container.Singleton<IEventAggregator, Caliburn.Micro.EventAggregator>(); // Mediator poskytovaný frameworkem

            _container.Singleton<IViewModelResolver<IViewModel>, ViewModelResolver>();

            // Přidáme ViewModel hlavního okna
            _container.Singleton<MainViewModel>();


            // Zde si do DI kontejneru přidáme jednotlivé pohledy
            // pohledy registruji taky jako Singletony, potom je načítám lazy
            _container.Singleton<FirstViewModel>(nameof(FirstViewModel));
            _container.Singleton<SecondViewModel>(nameof(SecondViewModel));


            _container.Instance(_container);
        }


        // Tahle metoda se zavolá při startu aplikace, po metodě Configure()
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            // Při startu aplikace chceme zobrazit hlavní okno
            // Proto řekneme DI kontejneru, aby nám dal objekt implementující rozhraní IWindowManager,
            // který má metodu ShowWindow(), které se předá instance konkrétního ViewModelu a tento
            // WindowManager nám zobrazí odpovídající okno (dohledá si sám, podle názvu)
            _container.GetInstance<IWindowManager>().ShowWindow(_container.GetInstance<MainViewModel>());
        }


        protected override void OnExit(object sender, EventArgs e)
        {
            // Tahle metoda se zavolá před ukončením aplikace
            // Lze tu provést úklid, než se aplikace vypne
        }


        // ----- Přetížené metody níže se vztahují k DI kontejneru.
        // Pokud bychom ho nepoužívali, tak by tu nemuseli být.


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
