using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CaliburnExample.FlashMessages
{
    public class FlashMessagesManager : PropertyChangedBase, IFlashMessagesManager
    {
        private ObservableCollection<FlashMessage> _flashMessages;
        public ObservableCollection<FlashMessage> FlashMessages
        {
            get { return _flashMessages; }
        }


        private bool _isEmpty;
        public bool IsEmpty
        {
            get { return _isEmpty; }
            set
            {
                _isEmpty = value;
                NotifyOfPropertyChange(() => IsEmpty);
            }
        }


        public FlashMessagesManager()
        {
            _flashMessages = new ObservableCollection<FlashMessage>();
            IsEmpty = true;
        }


        public void DisplayFlashMessages(FlashMessagesCollection flashMessagesCollection)
        {
            ClearFlashMessages();
            IsEmpty = false;
            var t = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(300) };
            t.Tick += (o, e) => {
                if (flashMessagesCollection.IsEmpty) {
                    t.Stop();
                    return;
                }
                _flashMessages.Add(flashMessagesCollection.CutFirst());
            };
            t.Start();
        }


        public void DisplayFlashMessage(string message, Type type)
        {
            ClearFlashMessages();
            IsEmpty = false;
            _flashMessages.Add(new FlashMessage(message, type));
        }


        public void ClearFlashMessages()
        {
            _flashMessages.Clear();
            IsEmpty = true;
        }
    }
}
