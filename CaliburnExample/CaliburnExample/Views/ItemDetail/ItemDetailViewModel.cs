using Caliburn.Micro;
using CaliburnExample.Domain;
using CaliburnExample.EventAggregator.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnExample.Views.ItemDetail
{
    // Tenhle view model bude přijímat zprávy DisplayCarDetailMessage od jiných view modelů
    public class ItemDetailViewModel : Screen, IViewModel, IHandle<DisplayCarDetailMessage>
    {
        private Car _car;
        public Car Car
        {
            get { return _car; }
        }


        public ItemDetailViewModel(
            IEventAggregator eventAggregator
        ) {
            eventAggregator.Subscribe(this);
        }


        // když někdo odešle zprávu DisplayCarDetailMessage, tak ji zachytíme a zpracujeme
        public void Handle(DisplayCarDetailMessage message)
        {
            _car = message.Car;
            NotifyOfPropertyChange(() => Car);
        }
    }
}
