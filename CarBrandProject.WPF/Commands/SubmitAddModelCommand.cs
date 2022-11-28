using CarBrandProject.WPF.Models;
using CarBrandProject.WPF.Stores;
using CarBrandProject.WPF.ViewModels;
using System;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Commands
{
    public class SubmitAddModelCommand : AsyncBaseCommand
    {
        private ModalNavigationStore _modalNavigationStore;
        private AddModelViewModel _addModelViewModel;
        private ModelsStore _modelsStore;      
        public SubmitAddModelCommand(ModelsStore modelsStore, AddModelViewModel addModelViewModel, ModalNavigationStore modalNavigationStore)
        {
            _modelsStore = modelsStore;
            _addModelViewModel = addModelViewModel;
            _modalNavigationStore = modalNavigationStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            //TODO: Add model to database
            ModelDetailsFormViewModel modelDetailsFormViewModel = _addModelViewModel.ModelDetailsFormViewModel;
            ModelsModel modelsModel = new ModelsModel(Guid.NewGuid(),
                modelDetailsFormViewModel.ModelName,
                modelDetailsFormViewModel.TypeOfFuel,
                modelDetailsFormViewModel.DateOnMarket,
                modelDetailsFormViewModel.ModelClass,
                modelDetailsFormViewModel.PassangerCapacity,
                modelDetailsFormViewModel.Price,
                modelDetailsFormViewModel.IsAvalable);

            try
            {
                await _modelsStore.Add(modelsModel);
                _modalNavigationStore.Close();
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
