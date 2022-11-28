using CarBrandProject.WPF.Commands;
using CarBrandProject.WPF.Stores;
using System.Windows.Input;

namespace CarBrandProject.WPF.ViewModels
{
    public class AddBrandViewModel : BaseViewModel
    {
        public BrandDetailsFormViewModel BrandDetailsFormViewModel { get; set; }
        public AddBrandViewModel(BrandsStores brandsStores, ModalNavigationStore modalNavigationStore)
        {
            ICommand submitBrandCommand = new SubmitAddBrandCommand(this, brandsStores, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            BrandDetailsFormViewModel = new BrandDetailsFormViewModel(submitBrandCommand, cancelCommand);
        }    
    }
}
