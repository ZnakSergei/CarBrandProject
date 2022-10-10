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
        private BrandItemListing _brandItemListing;
        private BrandsStores _brandsStores;
        public OpenEditBrandCommand(BrandItemListing brandItemListing, BrandsStores brandsStores, ModalNavigationStore modalNavigationStore)
        {
            _brandItemListing = brandItemListing;
            _brandsStores = brandsStores;
            _modalNavigationStore = modalNavigationStore;
        }
        public override void Execute(object? parameter)
        {
            BrandModel brandModel = _brandItemListing.BrandModel;
            EditBrandDetailsViewModel editBrandDetailsViewModel = new EditBrandDetailsViewModel(brandModel, _brandsStores, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editBrandDetailsViewModel;
        }
    }
}
