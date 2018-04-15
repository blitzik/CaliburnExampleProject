using Caliburn.Micro;
using CaliburnExample.Domain;
using CaliburnExample.EventAggregator.Messages;
using CaliburnExample.Views.Default;

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

            DisplayView(nameof(DefaultViewModel));
        }


        public void Handle(ChangeViewMessage message)
        {
            DisplayView(message.ViewModelName);
        }
    }
}
