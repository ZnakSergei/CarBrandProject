using CarBrandProject.WPF.Components;
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
    public class DeleteModelItemViewModelCommand : AsyncBaseCommand
    {
        private ModelsStore _modelStore;
        private ModelListingItemViewModel _modelListingItemViewModel;

        public DeleteModelItemViewModelCommand(ModelsStore modelStore, ModelListingItemViewModel modelListingItemViewModel)
        {
            _modelStore = modelStore;
            _modelListingItemViewModel = modelListingItemViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            ModelsModel modelsModel = _modelListingItemViewModel.ModelsModel;
            try
            {
                await _modelStore.Delete(modelsModel.ModelId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
