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
        public BrandDetailsFormViewModel BrandDetailsFormViewModel { get; set; }

        public EditBrandDetailsViewModel(BrandModel brandModel, ModalNavigationStore modalNavigationStore)
        {
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);

            BrandDetailsFormViewModel = new BrandDetailsFormViewModel(null, cancelCommand)
            {
                BrandName = brandModel.BrandName,
                BrandDescription = brandModel.Description,
                ImagePath = brandModel.ImageBrandPath
            };
        }
    }
}
