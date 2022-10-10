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
        private readonly ModelsStore _modelsStore;
        private ModalNavigationStore _modalNavigationStore;
        public OpenAddModelCommand(ModelsStore modelsStore, ModalNavigationStore modalNavigationStore)
        {
            _modelsStore = modelsStore;
            _modalNavigationStore = modalNavigationStore;
        }
        public override void Execute(object? parameter)
        {
            AddModelViewModel addModelViewModel = new AddModelViewModel(_modelsStore ,_modalNavigationStore);

            _modalNavigationStore.CurrentViewModel = addModelViewModel;
        }
    }
}
