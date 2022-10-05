using CarBrandProject.WPF.Stores;
using CarBrandProject.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Commands
{
    public class OpenAddModelCommand : BaseCommand
    {
        private ModalNavigationStore _modalNavigationStore;

        public OpenAddModelCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            AddModelViewModel addModelViewModel = new AddModelViewModel(_modalNavigationStore);

            _modalNavigationStore.CurrentViewModel = addModelViewModel;
        }

    }
}
