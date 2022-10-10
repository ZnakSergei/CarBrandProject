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
    public class SubmitEditModelCommand : BaseCommand
    {
        private ModalNavigationStore _modalNavigationStore;
        private EditModelDetailsViewModel _editModelDetailsViewModel;
        private ModelsStore _modelsStore;
        public SubmitEditModelCommand(EditModelDetailsViewModel editModelDetailsViewModel, ModelsStore modelsStore, ModalNavigationStore modalNavigationStore)
        {
            _editModelDetailsViewModel = editModelDetailsViewModel;
            _modelsStore = modelsStore;
            _modalNavigationStore = modalNavigationStore;
        }
        public override async void Execute(object? parameter)
        {
            //TODO: Edit model to database
            ModelDetailsFormViewModel modelDetailsFormViewModel = _editModelDetailsViewModel.ModelDetailsFormViewModel;
            ModelsModel modelsModel = new ModelsModel(_editModelDetailsViewModel.ModelId,
                modelDetailsFormViewModel.ModelName,
                modelDetailsFormViewModel.TypeOfFuel,
                modelDetailsFormViewModel.DateOnMarket,
                modelDetailsFormViewModel.ModelClass,
                modelDetailsFormViewModel.PassangerCapacity,
                modelDetailsFormViewModel.Price,
                modelDetailsFormViewModel.IsAvalable);

            try
            {
                await _modelsStore.Update(modelsModel);
                _modalNavigationStore.Close();
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
