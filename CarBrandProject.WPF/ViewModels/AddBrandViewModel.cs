using CarBrandProject.WPF.Commands;
using CarBrandProject.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarBrandProject.WPF.ViewModels
{
    public class AddBrandViewModel : BaseViewModel
    {
        public BrandDetailsFormViewModel BrandDetailsFormViewModel { get; set; }
        public AddBrandViewModel(ModalNavigationStore modalNavigationStore)
        {
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            BrandDetailsFormViewModel = new BrandDetailsFormViewModel(null, cancelCommand);
        }

        
    }
}
