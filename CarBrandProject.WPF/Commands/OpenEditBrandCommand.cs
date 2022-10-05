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
    public class OpenEditBrandCommand : BaseCommand
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly BrandModel _brandModel;

        public OpenEditBrandCommand(BrandModel brandModel, ModalNavigationStore modalNavigationStore)
        {
            _brandModel = brandModel;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            EditBrandDetailsViewModel editBrandDetailsViewModel = new EditBrandDetailsViewModel(_brandModel, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editBrandDetailsViewModel;
        }
    }
}
