using CarBrandProject.WPF.Commands;
using CarBrandProject.WPF.Models;
using CarBrandProject.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarBrandProject.WPF.ViewModels
{
    public class EditBrandDetailsViewModel : BaseViewModel
    {
        public Guid BrandId { get; }
        public BrandDetailsFormViewModel BrandDetailsFormViewModel { get; set; }
        public EditBrandDetailsViewModel(BrandModel brandModel, BrandsStores brandsStores, ModalNavigationStore modalNavigationStore)
        {
            BrandId = brandModel.Id;

            ICommand submitBrandCommand = new SubmitEditBrandCommand(this, brandsStores, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);

            BrandDetailsFormViewModel = new BrandDetailsFormViewModel(submitBrandCommand, cancelCommand)
            {
                BrandName = brandModel.BrandName,
                BrandDescription = brandModel.Description,
                ImagePath = brandModel.ImageBrandPath,                
            };
        }
    }
}
