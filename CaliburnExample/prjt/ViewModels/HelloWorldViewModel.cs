using prjt.FlashMessages;
using prjt.Validation;
using prjt.ViewModels.Base;
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
            //FlashMessage("Success flash message", Project.FlashMessages.Type.SUCCESS);
            FlashMessages(new FlashMessagesCollection()
                .Add("Info flash message", prjt.FlashMessages.Type.INFO)
                .Add("Success flash message", prjt.FlashMessages.Type.SUCCESS)
                .Add("Warning flash message", prjt.FlashMessages.Type.WARNING)
                .Add("Error flash message", prjt.FlashMessages.Type.ERROR)
            );
        }
    }
}
