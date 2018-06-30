using Project.FlashMessages;
using Project.Validation;
using Project.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
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
            //FlashMessage("Success flash message", Project.FlashMessages.Type.SUCCESS);
            FlashMessages(new FlashMessagesCollection()
                .Add("Info flash message", Project.FlashMessages.Type.INFO)
                .Add("Success flash message", Project.FlashMessages.Type.SUCCESS)
                .Add("Warning flash message", Project.FlashMessages.Type.WARNING)
                .Add("Error flash message", Project.FlashMessages.Type.ERROR)
            );
        }
    }
}
