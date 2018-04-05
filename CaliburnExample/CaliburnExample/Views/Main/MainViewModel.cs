using Caliburn.Micro;
using CaliburnExample.EventAggregator.Messages;
using CaliburnExample.Services.ViewModelResolver;
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
    public class MainViewModel : Conductor<IViewModel>.Collection.OneActive, IHandle<ChangeViewMessage>
    {
        // MainViewModel bude reprezentovat výchozí okno, které bude načítat a přepínat další pohledy.
        // Conductor<IViewModel>.Collection.OneActive znamená, že MainViewModel bude obsahovat a řídit
        // ostatní pohledy, ale pouze jeden pohled bude moci být aktivní v jednu chvíli (OneActive).
        // Existuje ještě jedna třída "AllActive" a tam můžeme nastavit více aktivních pohledů v jednu chvíli.


        private IViewModelResolver<IViewModel> _viewModelResolver;
        private Dictionary<string, IViewModel> _viewModels;


        public MainViewModel(
            IEventAggregator eventAggregator,
            IViewModelResolver<IViewModel> viewModelResolver
        ) {
            _viewModels = new Dictionary<string, IViewModel>();
            _viewModelResolver = viewModelResolver;

            // zaregistrujeme třídu do EventAggregatoru, aby naslouchala konkrétním příchozím zprávám
            // Hlavní okno bude naslouchat zprávám ChangeViewMessage (Proto je implementováno rozhraní IHandle<ChangeViewMessage>)
            eventAggregator.Subscribe(this);
        }


        // ----- implementace rozhraní IHandle<ChangeViewMessage>
        
        public void Handle(ChangeViewMessage message)
        {
            // Když nějaká třída odešle zprávu ChangeViewMessage, tak ji zachytíme a pracujeme
            // ChangeViewMessage obsahuje název ViewModelu, který zaktivujeme a tím zobrazíme odpovídající pohled
            ActivateItem(GetViewModel(message.ViewModelName));
        }


        // ----- pomocné metody

        // přetížená metoda ActivateItem, která se používá pro "zaktivnění" konkrétního pohledu.
        // normálně je při aktivování daný IViewModel vždy přidán do kolekce (takto se chová pouze OneActive) view modelů.
        // Tady potom dost záleží na implementaci. Já to řeším tak, že načítám vždy stejný IViewModel a netvořím vždy nový, proto
        // mám v hlavním okně ještě Dictionary (_viewModels) se všemi načtenými view modely a kontroluji, zda-li již požadovaný viewmodel neexistuje.
        // (načítají se postupně a ne najednou při startu aplikace (lazy chování))
        public override void ActivateItem(IViewModel item)
        {
            // pokud budu klikat jak šílenec na tlačítko, které má aktivovat nějaký pohled,
            // tak ho nebudu dokola aktivovat
            if (ActiveItem == item) {
                return;
            }

            string typeName = item.GetType().Name;
            if (!_viewModels.ContainsKey(typeName)) {
                _viewModels.Add(typeName, item);
            }

            base.ActivateItem(item);
        }


        // získávání konkrétního view modelu podle názvu view modelu
        private IViewModel GetViewModel(string viewModelName)
        {
            IViewModel viewModel;
            if (!_viewModels.ContainsKey(viewModelName)) {
                viewModel = _viewModelResolver.Resolve(viewModelName);
                if (viewModel == null) {
                    throw new Exception("Requested ViewModel does not Exist!");
                }
                _viewModels.Add(viewModelName, viewModel);

            } else {
                viewModel = _viewModels[viewModelName];
            }

            return viewModel;
        }
    }
}
