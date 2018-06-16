using CaliburnExample.FlashMessages;
using CaliburnExample.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnExample.Views.HelloWorld
{
    public class HelloWorldViewModel : BaseScreen
    {
        private string _age;
        public string Age
        {
            get { return _age; }
            set
            {
                ClearMessages();
                int result;
                if (!int.TryParse(value, out result)) {
                    AddMessage("Age must be an integer number!", Severity.INFO);
                }

                _age = value;
                NotifyOfPropertyChange(() => Age);
            }
        }


        public void ClickMe()
        {
            FlashMessages(new FlashMessagesCollection()
                .Add("Info flash message", CaliburnExample.FlashMessages.Type.INFO)
                .Add("Success flash message", CaliburnExample.FlashMessages.Type.SUCCESS)
                .Add("Warning flash message", CaliburnExample.FlashMessages.Type.WARNING)
                .Add("Error flash message", CaliburnExample.FlashMessages.Type.ERROR)
            );
        }
    }
}
