using CaliburnExample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnExample.Security
{
    public interface IIdentity
    {
        User User { get; }
    }
}
