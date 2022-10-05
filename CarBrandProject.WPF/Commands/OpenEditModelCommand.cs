using CarBrandProject.WPF.Models;
using CarBrandProject.WPF.Stores;
using CarBrandProject.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Commands
{
    public class OpenEditModelCommand : BaseCommand
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly ModelsModel _modelsModel;

        public OpenEditModelCommand(ModelsModel modelsModel, ModalNavigationStore modalNavigationStore)
        {
            
            _modalNavigationStore = modalNavigationStore;
            _modelsModel = modelsModel;
        }

        public override void Execute(object? parameter)
        {
            EditModelDetailsViewModel editModelDetailsViewModel = new EditModelDetailsViewModel(_modelsModel, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editModelDetailsViewModel;
        }
    }
}
