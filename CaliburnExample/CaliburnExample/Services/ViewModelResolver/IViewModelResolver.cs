using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnExample.Services.ViewModelResolver
{
    public interface IViewModelResolver<T>
    {
        T Resolve(string viewModel);
    }
}
