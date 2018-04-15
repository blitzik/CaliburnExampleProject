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
                    AddMessage("Age must be an integer number!"); // povinný je pouze první parametr
                    // AddMessage("Age must be an integer number!", Severity.INFO); // Druhý parametr je defaultně nastaven na Severity.Error
                    // AddMessage("Age must be an integer number!", Severity.INFO, nameof(Age)); // třetí parametr nemusíš psát, pokud se zpráva vztahuje k property, kde tu metodu voláš
                }

                _age = value;
                NotifyOfPropertyChange(() => Age);
            }
        }
    }
}
