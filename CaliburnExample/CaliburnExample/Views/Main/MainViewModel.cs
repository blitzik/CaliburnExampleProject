using Caliburn.Micro;
using CaliburnExample.EventAggregator.Messages;

namespace CaliburnExample.Views.Main
{
    public class MainViewModel : BaseConductorOneActive, IHandle<ChangeViewMessage>
    {
        public MainViewModel()
        {
        }


        protected override void OnInitialize()
        {
            base.OnInitialize();

            EventAggregator.Subscribe(this);            
        }


        public void Handle(ChangeViewMessage message)
        {
            DisplayView(message.ViewModelName);
        }
    }
}
