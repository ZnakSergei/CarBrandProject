using CarBrandProject.WPF.Models;
using CarBrandProject.WPF.Stores;
using CarBrandProject.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Commands
{
    public class SubmitAddBrandCommand : AsyncBaseCommand
    {
        private readonly AddBrandViewModel _addBrandViewModel;
        private readonly BrandsStores _brandsStores;
        private ModalNavigationStore _modalNavigationStore;
        public SubmitAddBrandCommand(AddBrandViewModel addBrandViewModel, BrandsStores brandsStores, ModalNavigationStore modalNavigationStore)
        {
            _addBrandViewModel = addBrandViewModel;
            _brandsStores = brandsStores;
            _modalNavigationStore = modalNavigationStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            BrandDetailsFormViewModel brandFormViewModel = _addBrandViewModel.BrandDetailsFormViewModel;
            BrandModel brandModel = new BrandModel(Guid.NewGuid(), brandFormViewModel.BrandName, brandFormViewModel.BrandDescription, brandFormViewModel?.ImagePath,
                new ObservableCollection<ModelListingItemViewModel>());
            //TODO : Add brand to database
            try
            {
                await _brandsStores.Add(brandModel);

                _modalNavigationStore.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
