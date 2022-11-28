using CarBrandProject.WPF.Models;
using CarBrandProject.WPF.Stores;
using CarBrandProject.WPF.ViewModels;

namespace CarBrandProject.WPF.Commands
{
    public class OpenEditModelCommand : BaseCommand
    {
        private readonly ModelListingItemViewModel _modelListingItemViewModel;
        private readonly ModelsStore _modelsStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        public OpenEditModelCommand(ModelListingItemViewModel modelListingItemViewModel, ModelsStore modelsStore, ModalNavigationStore modalNavigationStore)
        {
            _modelListingItemViewModel = modelListingItemViewModel;
            _modelsStore = modelsStore;
            _modalNavigationStore = modalNavigationStore;
           
        }
        public override void Execute(object? parameter)
        {
            ModelsModel modelsModel = _modelListingItemViewModel.ModelsModel;
            EditModelDetailsViewModel editModelDetailsViewModel = new EditModelDetailsViewModel(modelsModel, _modelsStore, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editModelDetailsViewModel;
        }
    }
}
