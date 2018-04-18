using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnExample.Views.Registration
{
    public class RegistrationViewModel : BaseScreen
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                NotifyOfPropertyChange(() => Username);
            }
        }


        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }


        public delegate void SuccessfulRegistrationHandler(object sender, Domain.User user);
        public event SuccessfulRegistrationHandler OnSuccessfullRegistration;
        public void SignUp()
        {
            // tady provedeš registraci


            if (true) { // podmínku si uprav tak, aby se zavolala při úspěšný registraci
                // při úspěšný registraci zpracujeme přidané callbacky
                SuccessfulRegistrationHandler handler = OnSuccessfullRegistration;
                if (handler != null) {
                    handler(this, new Domain.User(Username, Password));
                }
                TryClose();
            }
        }


        public void ReturnBack()
        {
            TryClose();
        }
    }
}
