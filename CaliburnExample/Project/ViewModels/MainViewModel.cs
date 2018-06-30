using Caliburn.Micro;
using Project.EventAggregator.Messages;
using Project.ViewModels.Base;

namespace Project.ViewModels
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
