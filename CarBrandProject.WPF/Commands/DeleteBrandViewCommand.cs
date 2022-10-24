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
    public class DeleteBrandViewCommand : AsyncBaseCommand
    {
        private readonly BrandItemListing _brandItemListing;
        private readonly BrandsStores _brandsStores;

        public DeleteBrandViewCommand(BrandItemListing brandItemListing, BrandsStores brandsStores)
        {
            _brandItemListing = brandItemListing;
            _brandsStores = brandsStores;           
        }

        public override async Task ExecuteAsync(object parameter)
        {
            BrandModel brandModel = _brandItemListing.BrandModel;

            try
            {
                await _brandsStores.Delete(brandModel.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
