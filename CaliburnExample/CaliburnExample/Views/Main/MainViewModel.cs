using Caliburn.Micro;
using CaliburnExample.EventAggregator.Messages;
using CaliburnExample.Views.HelloWorld;

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

            ActivateItem(nameof(HelloWorldViewModel));
        }


        public void Handle(ChangeViewMessage message)
        {
            if (message.ViewModel != null) {
                ActivateItem(message.ViewModel);
            } else {
                ActivateItem(message.ViewModelName);
            }
        }
    }
}
