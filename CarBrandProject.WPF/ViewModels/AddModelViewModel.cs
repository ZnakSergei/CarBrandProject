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
    public class AddModelViewModel : BaseViewModel
    {
        public ModelDetailsFormViewModel ModelDetailsFormViewModel { get; set; }

        public AddModelViewModel(ModalNavigationStore modalNavigationStore)
        {
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            ModelDetailsFormViewModel = new ModelDetailsFormViewModel(null, cancelCommand);
        }
    }
}
