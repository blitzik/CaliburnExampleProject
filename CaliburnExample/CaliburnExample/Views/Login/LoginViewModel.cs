using Caliburn.Micro;
using CaliburnExample.Domain;
using CaliburnExample.Services.ViewModelResolver;
using CaliburnExample.Views.Registration;
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


        // property injection
        private IViewModelResolver<IViewModel> _viewModelResolver;
        public IViewModelResolver<IViewModel> ViewModelResolver
        {
            get { return _viewModelResolver; }
            set { _viewModelResolver = value; }
        }


        private IWindowManager _windowManager;


        public LoginViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }


        public delegate void  LoginSuccessHandler(object sender, User user);
        public event LoginSuccessHandler OnSuccessfullLogin;

        public void Login()
        {
            ResultMessage = string.Empty;


            // tady si provedeš validaci a kontrolu zadaných přihlašovacích údajů


            if (true) { // tady si zadej podmínku, kdy přihlášení bude v pořádku
                LoginSuccessHandler handler = OnSuccessfullLogin;
                if (handler != null) {
                    handler(this, new User(Username, Password));
                }

            } else {
                ResultMessage = "Wrong Credentials";
            }
        }


        public void AddUser()
        {
            RegistrationViewModel rvm = (RegistrationViewModel)ViewModelResolver.Resolve(nameof(RegistrationViewModel));
            rvm.OnSuccessfullRegistration += (object sender, User user) =>
            {
                LoginSuccessHandler handler = OnSuccessfullLogin;
                if (handler != null) {
                    handler(this, user);
                }
            };

            _windowManager.ShowDialog(rvm);
        }
    }
}
