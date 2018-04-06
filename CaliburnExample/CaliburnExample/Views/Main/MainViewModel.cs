using Caliburn.Micro;
using CaliburnExample.EventAggregator.Messages;
using CaliburnExample.Services.ViewModelResolver;
using CaliburnExample.Views.FirstView;
using CaliburnExample.Views.SecondView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnExample.Views.Main
{
    // Název ViewModelu vychází z názvu View, jen je za slovo View ještě přidáno Model
    // MainView      -> pohled
    // MainViewModel -> view model
    public class MainViewModel : BaseConductorOneActive, IHandle<ChangeViewMessage>
    {
        public MainViewModel(
            IEventAggregator eventAggregator,
            IViewModelResolver<IViewModel> viewModelResolver
        ) : base(eventAggregator, viewModelResolver)
        {
        }


        // ----- Obsluha tlačítek


        public void DisplayFirstView()
        {
            ActivateItem(GetViewModel(nameof(FirstViewModel)));
        }


        public void DisplaySecondView()
        {
            ActivateItem(GetViewModel(nameof(SecondViewModel)));
        }


        // ----- implementace rozhraní IHandle<ChangeViewMessage>

        // zatím nevyužitá metoda, ale hlavní okno je tímto připraveno přijímat požadavky z jiných view modelů na změnu pohledu
        public void Handle(ChangeViewMessage message)
        {
            // Když nějaká třída odešle zprávu ChangeViewMessage, tak ji zachytíme a pracujeme
            // ChangeViewMessage obsahuje název ViewModelu, který zaktivujeme a tím zobrazíme odpovídající pohled
            ActivateItem(GetViewModel(message.ViewModelName));
        }
    }
}
