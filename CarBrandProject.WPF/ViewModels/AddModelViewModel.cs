using CarBrandProject.WPF.Commands;
using CarBrandProject.WPF.Stores;
using System.Windows.Input;

namespace CarBrandProject.WPF.ViewModels
{
    public class AddModelViewModel : BaseViewModel
    {      
        public ModelDetailsFormViewModel ModelDetailsFormViewModel { get; set; }
        public AddModelViewModel(ModelsStore modelsStore, ModalNavigationStore modalNavigationStore)
        {
            ICommand submitModelCommand = new SubmitAddModelCommand(modelsStore, this, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            
            ModelDetailsFormViewModel = new ModelDetailsFormViewModel(submitModelCommand, cancelCommand);            
        }
    }
}
