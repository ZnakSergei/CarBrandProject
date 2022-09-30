using CarBrandProject.WPF.Models;
using CarBrandProject.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.ViewModels
{
    public class ModelsViewModel : BaseViewModel
    {
        public ObservableCollection<ModelListingItemViewModel> Models { get; set; }
        private readonly SelectedModelStores _selectedModelStore;

        private ModelListingItemViewModel _selectedModel;
        public ModelListingItemViewModel SelectedModel
        {
            get
            {
                return _selectedModel;
            }
            set
            {
                _selectedModel = value;
                OnPropertyChanged(nameof(SelectedModel));

                _selectedModelStore.ModelStore = _selectedModel.ModelsModel;
            }
        }
        public ModelsViewModel(SelectedModelStores selectedModelStores)
        {
            Models = new ObservableCollection<ModelListingItemViewModel>();

            Models.Add(new ModelListingItemViewModel( new ModelsModel()
            {
                ModelName = "Model1",
                TypeOfFuel = "Gas",
                DateonMarket = "12.11.2012",
                ModelClass = "Family car",
                Price = 12000,
                PassangerCapacity = 5,
                IsAvalable = true
            }));

            Models.Add(new ModelListingItemViewModel(new ModelsModel()
            {
                ModelName = "Model2",
                TypeOfFuel = "Gas",
                DateonMarket = "12.11.2012",
                ModelClass = "Family car",
                Price = 12000,
                PassangerCapacity = 5,
                IsAvalable = true
            }));

            Models.Add(new ModelListingItemViewModel(new ModelsModel()
            {
                ModelName = "Model3",
                TypeOfFuel = "Gas",
                DateonMarket = "12.11.2012",
                ModelClass = "Family car",
                Price = 12000,
                PassangerCapacity = 5,
                IsAvalable = true
            }));

            _selectedModelStore = selectedModelStores;
        }

    }
    public class ModelListingItemViewModel : BaseViewModel
    {
        public ModelsModel ModelsModel { get; set; }
        
        public string ModelName => ModelsModel.ModelName;
        public ModelListingItemViewModel(ModelsModel modelsModel)
        {
            ModelsModel = modelsModel;
        }

    }

    public class ModelDetails : BaseViewModel
    {
        private SelectedModelStores _selectedModelStores;
        private ModelsModel SelectedModel => _selectedModelStores.ModelStore;
        public string ModelName => SelectedModel?.ModelName ?? "Unknown";
        public string TypeOfFuel => SelectedModel?.TypeOfFuel ?? "Unknown";
        public string DateonMarket => SelectedModel?.DateonMarket;
        public string ModelClass => SelectedModel?.ModelClass ?? "Unknown";
        public int Price => SelectedModel?.Price ?? 0;
        public int PassangerCapacity => SelectedModel?.PassangerCapacity ?? 0;
        //public string IsAvalable => SelectedModel?.IsAvalable ?? "Yes" : "No";

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
            OnPropertyChanged(nameof(DateonMarket));
            OnPropertyChanged(nameof(ModelClass));
            OnPropertyChanged(nameof(Price));
            OnPropertyChanged(nameof(PassangerCapacity));
            //OnPropertyChanged(nameof(IsAvalable));
        }
    }
}
