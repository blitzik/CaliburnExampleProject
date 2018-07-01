using Common.FlashMessages;
using Common.Validation;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjt.ViewModels
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
            FlashMessagesManager.AddFlashMessage("Info flash message", Common.FlashMessages.Type.INFO)
                                .AddFlashMessage("Success flash message", Common.FlashMessages.Type.SUCCESS)
                                .AddFlashMessage("Warning flash message", Common.FlashMessages.Type.WARNING)
                                .AddFlashMessage("Error flash message", Common.FlashMessages.Type.ERROR)
                                .DisplayFlashMessages();
        }
    }
}
