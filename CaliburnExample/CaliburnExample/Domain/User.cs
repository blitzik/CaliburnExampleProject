using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnExample.Domain
{
    public class User
    {
        private string _username;
        public string Username
        {
            get { return _username; }
        }


        private string _password;
        public string Password
        {
            get { return _password; }
        }


        public User(string username, string password)
        {
            _username = username;
            _password = password;
        }
    }
}
