using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.FlashMessages
{
    public enum Type
    {
        INFO,
        SUCCESS,
        WARNING,
        ERROR
    }

    public interface IFlashMessagesManager
    {
        bool IsEmpty { get; }
        ObservableCollection<FlashMessage> FlashMessages { get; }

        void DisplayFlashMessages(FlashMessagesCollection notifications);
        void DisplayFlashMessage(string message, Type type);
        void ClearFlashMessages();        
    }
}
