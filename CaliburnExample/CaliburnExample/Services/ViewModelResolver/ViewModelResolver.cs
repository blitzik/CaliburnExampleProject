using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaliburnExample.Views;
using Caliburn.Micro;

namespace CaliburnExample.Services.ViewModelResolver
{
    // Třída, která nám podle klíče (názvu ViewModelu) vrátí instanci konkrétního ViewModelu
    public class ViewModelResolver : IViewModelResolver<Views.IViewModel>
    {
        private readonly SimpleContainer _container;


        public ViewModelResolver(SimpleContainer container)
        {
            _container = container;
        }


        public IViewModel Resolve(string viewModel)
        {
            return (IViewModel)_container.GetInstance(Type.GetType(viewModel), viewModel);
        }
    }
}
