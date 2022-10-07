using CarBrandProject.WPF.Stores;
using CarBrandProject.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarBrandProject.WPF.Commands
{
    public class OpenAddBrandCommand : BaseCommand
    {
        private readonly BrandsStores _brandsStores;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenAddBrandCommand(BrandsStores brandsStores, ModalNavigationStore modalNavigationStore)
        {
            _brandsStores = brandsStores;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            AddBrandViewModel addBrandViewModel = new AddBrandViewModel(_brandsStores , _modalNavigationStore);

            _modalNavigationStore.CurrentViewModel = addBrandViewModel;
        }
    }
}
