using CarBrandProject.WPF.Models;
using CarBrandProject.WPF.Stores;
using CarBrandProject.WPF.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Commands
{
    public class SubmitEditBrandCommand : AsyncBaseCommand
    {
        private readonly EditBrandDetailsViewModel _editBrandDetailsViewModel;
        private readonly BrandsStores _brandsStores;
        private ModalNavigationStore _modalNavigationStore;
        public SubmitEditBrandCommand(EditBrandDetailsViewModel editBrandDetailsViewModel, BrandsStores brandsStores, ModalNavigationStore modalNavigationStore)
        {
            _editBrandDetailsViewModel = editBrandDetailsViewModel;
            _brandsStores = brandsStores;
            _modalNavigationStore = modalNavigationStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            //TODO: Edit brand to database
            BrandDetailsFormViewModel brandFormViewModel = _editBrandDetailsViewModel.BrandDetailsFormViewModel;
           
            BrandModel brandModel = new BrandModel(_editBrandDetailsViewModel.BrandId, brandFormViewModel.BrandName, brandFormViewModel.BrandDescription, brandFormViewModel.ImagePath,
                new ObservableCollection<ModelListingItemViewModel>());
            
            try
            {
                await _brandsStores.Update(brandModel);

                _modalNavigationStore.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
