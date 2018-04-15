using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnExample.Views.Login
{
    public class LoginViewModel : BaseScreen
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


        private string _resultMessage;
        public string ResultMessage
        {
            get { return _resultMessage; }
            set
            {
                _resultMessage = value;
                NotifyOfPropertyChange(() => ResultMessage);
            }
        }


        public delegate void  LoginSuccessHandler(object sender, EventArgs args);
        public event LoginSuccessHandler OnSuccessfullLogin;

        public void Login()
        {
            ResultMessage = string.Empty;


            // tady si provedeš validaci a kontrolu zadaných přihlašovacích údajů


            if (true) { // tady si zadej podmínku, kdy přihlášení bude v pořádku
                LoginSuccessHandler handler = OnSuccessfullLogin;
                if (handler != null) {
                    handler(this, EventArgs.Empty);
                }

            } else {
                ResultMessage = "Wrong Credentials";
            }
        }
    }
}
