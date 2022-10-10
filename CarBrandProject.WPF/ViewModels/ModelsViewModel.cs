using CarBrandProject.WPF.Commands;
using CarBrandProject.WPF.Models;
using CarBrandProject.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarBrandProject.WPF.ViewModels
{

    public class ModelListingItemViewModel : BaseViewModel
    {
        public ModelsModel ModelsModel { get; set; }
        
        public string ModelName => ModelsModel.ModelName;
        public ICommand EditModelCommand { get; set; }
        public ICommand DeleteModelCommand { get; set; }
        

        public ModelListingItemViewModel(ModelsModel modelsModel, ModelsStore modelsStore, ModalNavigationStore modalNavigationStore)
        {
            ModelsModel = modelsModel;
            EditModelCommand = new OpenEditModelCommand(this, modelsStore, modalNavigationStore);
        }

        internal void Update(ModelsModel modelsModel)
        {
            ModelsModel = modelsModel;

            OnPropertyChanged(nameof(ModelName));
        }
    }

    public class ModelDetails : BaseViewModel
    {
        private SelectedModelStores _selectedModelStores;
        private ModelsModel SelectedModel => _selectedModelStores.ModelStore;
        public bool HasSelectedModel => SelectedModel != null;
        public string ModelName => SelectedModel?.ModelName ?? "Unknown";
        public string TypeOfFuel => SelectedModel?.TypeOfFuel ?? "Unknown";
        public string DateOnMarket => SelectedModel?.DateOnMarket;
        public string ModelClass => SelectedModel?.ModelClass ?? "Unknown";
        public int Price => SelectedModel?.Price ?? 0;
        public int PassangerCapacity => SelectedModel?.PassangerCapacity ?? 0;
        public string IsAvalable => (SelectedModel?.IsAvalable ?? false) ? "Yes" : "No";

        public ModelDetails(SelectedModelStores selectedModelStores)
        {
            _selectedModelStores = selectedModelStores;

            _selectedModelStores.SelectedModelChanged += _selectedModelStores_SelectedModelChanged;
        }

        protected override void Dispose()
        {
            _selectedModelStores.SelectedModelChanged -= _selectedModelStores_SelectedModelChanged;
            base.Dispose();
        }

        private void _selectedModelStores_SelectedModelChanged()
        {
            OnPropertyChanged(nameof(ModelName));
            OnPropertyChanged(nameof(TypeOfFuel));
            OnPropertyChanged(nameof(DateOnMarket));
            OnPropertyChanged(nameof(ModelClass));
            OnPropertyChanged(nameof(Price));
            OnPropertyChanged(nameof(PassangerCapacity));
            OnPropertyChanged(nameof(IsAvalable));
        }
    }
}
