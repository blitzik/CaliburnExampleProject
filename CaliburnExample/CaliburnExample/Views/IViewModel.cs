using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnExample.Views
{
    // Každý ViewModel bude implementovat toto rozhraní, které potom budeme používat
    // v pohledu, který bude zárověň fungovat jako Conductor
    // (což je vpodstatě něco jako kontejner pro další pohledy, které poté budeme moci přepínat)
    public interface IViewModel
    {
        // zatím jen prázdné rozhraní
    }
}
