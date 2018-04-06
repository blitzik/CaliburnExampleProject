using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaliburnExample.Services.ViewModelResolver;
using System.Collections.ObjectModel;
using CaliburnExample.Domain;
using CaliburnExample.Views.ItemDetail;
using CaliburnExample.EventAggregator.Messages;

namespace CaliburnExample.Views.SecondView
{
    public class SecondViewModel : BaseConductorOneActive, IViewModel
    {
        private ObservableCollection<Car> _cars;
        public ObservableCollection<Car> Cars
        {
            get { return _cars; }
        }


        private Car _selectedCar;
        public Car SelectedCar
        {
            get { return _selectedCar; }
            set
            {
                _selectedCar = value;
                NotifyOfPropertyChange(() => SelectedCar);

                // při zvolení auta ze seznamu odešleme zprávu, která bude obsahovat zvolené auto.
                // view model, který bude implementovat rozhraní IHandle<ChangeViewMessage>, obdrží tuto zprávu
                _eventAggregator.PublishOnUIThread(new DisplayCarDetailMessage(value));
            }
        }


        public SecondViewModel(
            IEventAggregator eventAggregator,
            IViewModelResolver<IViewModel> viewModelResolver
        ) : base(eventAggregator, viewModelResolver)
        {
            _cars = new ObservableCollection<Car>();
            _cars.Add(new Car("Volkswagen", "Amarok", "Pickup", 4, 90));
            _cars.Add(new Car("Mercedes-Benz", "Maybach", "Sedan", 4, 335));
            _cars.Add(new Car("BMW", "220i", "Coupé", 2, 135));

            ActivateItem(GetViewModel(nameof(ItemDetailViewModel)));

            SelectedCar = _cars[0];
        }


    }
}
