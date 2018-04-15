using CaliburnExample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnExample.Security
{
    public class Identity : IIdentity
    {
        public User _user;
        public User User
        {
            get { return _user; }
        }


        public Identity(User user)
        {
            _user = user;
        }
    }
}
