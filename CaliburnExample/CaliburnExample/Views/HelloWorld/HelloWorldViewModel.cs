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
    }
}
