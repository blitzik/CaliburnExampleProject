using Caliburn.Micro;
using prjt.EventAggregator.Messages;
using prjt.ViewModels.Base;

namespace prjt.ViewModels
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
