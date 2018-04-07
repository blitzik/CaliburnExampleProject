using Caliburn.Micro;
using CaliburnExample.Services.ViewModelResolver;

namespace CaliburnExample.Views
{
    public abstract class BaseScreen : Screen, IViewModel
    {
        // property injection
        private IEventAggregator _eventAggregator;
        public IEventAggregator EventAggregator
        {
            get { return _eventAggregator; }
            set { _eventAggregator = value; }
        }
    }
}
