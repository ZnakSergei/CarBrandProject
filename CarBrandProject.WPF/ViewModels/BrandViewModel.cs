using CarBrandProject.WPF.Commands;
using CarBrandProject.WPF.Components;
using CarBrandProject.WPF.Models;
using CarBrandProject.WPF.Stores;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace CarBrandProject.WPF.ViewModels
{
    public class BrandViewModel : BaseViewModel
    {
        public ObservableCollection<BrandItemListing> Brands {get;set;}
        public ObservableCollection<ModelListingItemViewModel> Models {get;set;}

        private readonly SelectedBrandStores _selectedBrandStores;
        private readonly SelectedModelStores _selectedModelStores;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly BrandsStores _brandsStores;
        private readonly ModelsStore _modelsStore;
       
        public ICommand AddBrandCommand { get; set; }
        public ICommand AddModelCommand { get; set; }
        public ICommand LoadBrandCommand { get; set; }
        public ICommand LoadModelCommand { get; set; }

        private ModelListingItemViewModel _selectedModel;
        public ModelListingItemViewModel SelectedModel
        {
            get { return _selectedModel; }
            set
            {
                _selectedModel = value;
                OnPropertyChanged(nameof(SelectedModel));
                
                _selectedModelStores.ModelStore = _selectedModel?.ModelsModel;
            }
        }

        private BrandItemListing _selectedBrand;
        
        public BrandItemListing SelectedBrand
        {
            get { return _selectedBrand; }
            set
            {
                _selectedBrand = value;

                Models = Brands.FirstOrDefault(x => x.BrandName.Equals(_selectedBrand?.BrandName))?.BrandModel.BrandModels;
                
                OnPropertyChanged(nameof(SelectedBrand));
                OnPropertyChanged(nameof(Models));

                _selectedBrandStores.BrandStore = _selectedBrand?.BrandModel;              
            }
        }

        public BrandViewModel(BrandsStores brandsStores, SelectedBrandStores selectedBrandStores, ModelsStore modelsStore, 
            SelectedModelStores selectedModelStores, ModalNavigationStore modalNavigationStore)
        {
            Brands = new ObservableCollection<BrandItemListing>();
            Models = new ObservableCollection<ModelListingItemViewModel>();

            _selectedBrandStores = selectedBrandStores;
            _selectedModelStores = selectedModelStores;
            _modalNavigationStore = modalNavigationStore;
            _brandsStores = brandsStores;
            _modelsStore = modelsStore;

            _brandsStores.BrandAdded += _brandsStores_BrandAdded;
            _brandsStores.BrandEdited += _brandsStores_BrandUpdated;
            _brandsStores.BrandDeleted += _brandsStores_BrandDeleted;

            _brandsStores.BrandLoaded += _brandsStores_BrandLoaded;
            _modelsStore.ModelsLoaded += _modelsStore_ModelsLoaded;
            

            _modelsStore.ModelAdded += _modelsStore_ModelAdded;
            _modelsStore.ModelUpdate += _modelsStore_ModelUpdate;
            _modelsStore.ModelDelete += _modelsStore_ModelDelete;
            

            AddBrandCommand = new OpenAddBrandCommand(brandsStores, modalNavigationStore);
            AddModelCommand = new OpenAddModelCommand(modelsStore, modalNavigationStore);
            LoadBrandCommand = new LoadBrandCommand(brandsStores);
            LoadModelCommand = new LoadModelCommand(modelsStore);
        }

        private void _modelsStore_ModelDelete(Guid modelId)
        {
            ModelListingItemViewModel modelsListingItem = Models.FirstOrDefault(b => b.ModelsModel.ModelId == modelId);
            if (modelsListingItem != null)
            {
                Models.Remove(modelsListingItem);
            }
        }

        private void _brandsStores_BrandLoaded()
        {
            Brands.Clear();

            foreach (BrandModel brandModel in _brandsStores.brandModels)
            {
                AddBrand(brandModel);
            }
        }
        private void _brandsStores_BrandDeleted(Guid brandId)
        {
            BrandItemListing brandItemListing = Brands.FirstOrDefault(b => b.BrandModel.Id == brandId);

            if (brandItemListing != null)
            {
                Brands.Remove(brandItemListing);
            }
        }

        public static BrandViewModel LoadBrandViewModel(BrandsStores brandsStores, SelectedBrandStores selectedBrandStores, ModelsStore modelsStore,
            SelectedModelStores selectedModelStores, ModalNavigationStore modalNavigationStore)
        {
            BrandViewModel brandViewModel = new BrandViewModel(brandsStores, selectedBrandStores, modelsStore, selectedModelStores, modalNavigationStore);
            brandViewModel.LoadBrandCommand.Execute(null);
            
            return brandViewModel;
        }
        private void AddBrand(BrandModel brandModel)
        {
            BrandItemListing brandItem = new BrandItemListing(brandModel, _brandsStores, _modalNavigationStore);
            Brands.Add(brandItem);
        }

        private void _brandsStores_BrandAdded(BrandModel brandModel)
        {
            AddBrand(brandModel);
        }

        private void _brandsStores_BrandUpdated(BrandModel brandModel)
        {
            BrandItemListing brand = Brands.FirstOrDefault(b => b.BrandModel.Id == brandModel.Id);

            if (brand != null)
            {
                brand.Update(brandModel);
            }
        }
        private void _modelsStore_ModelsLoaded()
        {
            Models.Clear();
            foreach (var modelsModel in _modelsStore.modelsModels)
            {
                AddModels(modelsModel);
            }
        }

        private void _modelsStore_ModelAdded(ModelsModel modelsModel)
        {
            AddModels(modelsModel);
        }
        private void _modelsStore_ModelUpdate(ModelsModel modelsModel)
        {
            var model = Models.FirstOrDefault(m => m.ModelsModel.ModelId == modelsModel.ModelId);
            if (model != null)
            {
                model.Update(modelsModel);
            }
        }
        private void AddModels(ModelsModel modelsModel)
        {
            ModelListingItemViewModel modelItem = new ModelListingItemViewModel(modelsModel, _modelsStore, _modalNavigationStore);
            Models.Add(modelItem);
        }
  
        protected override void Dispose()
        {
            _brandsStores.BrandAdded -= _brandsStores_BrandAdded;
            _brandsStores.BrandEdited -= _brandsStores_BrandUpdated;
            _brandsStores.BrandLoaded -= _brandsStores_BrandLoaded;
            _brandsStores.BrandDeleted -= _brandsStores_BrandDeleted;

            _modelsStore.ModelsLoaded -= _modelsStore_ModelsLoaded;
            _modelsStore.ModelAdded -= _modelsStore_ModelAdded;
            _modelsStore.ModelUpdate -= _modelsStore_ModelUpdate;
            _modelsStore.ModelDelete -= _modelsStore_ModelDelete;

            base.Dispose();
        }       
    }

    public class BrandItemListing : BaseViewModel
    {
        public BrandModel BrandModel { get; set; }

        public string BrandName => BrandModel.BrandName;

        public ICommand EditBrandCommand { get; set; }
        public ICommand DeleteBrandCommand { get; set; }
        public BrandsStores BrandsStores { get; }
        public ModalNavigationStore ModalNavigationStore { get; }     

        public BrandItemListing(BrandModel brandModel, BrandsStores brandsStores, ModalNavigationStore modalNavigationStore)
        {
            BrandModel = brandModel;

            EditBrandCommand = new OpenEditBrandCommand(this, brandsStores, modalNavigationStore);
            DeleteBrandCommand = new DeleteBrandViewCommand(this, brandsStores);
        }

        public void Update(BrandModel brandModel)
        {
            BrandModel = brandModel;

            OnPropertyChanged(nameof(BrandName));
        }
    }

    public class BrandDetails : BaseViewModel
    {
        private readonly SelectedBrandStores _selectedBrandStores;
        private BrandModel SelectedBrand => _selectedBrandStores.BrandStore;
        public bool HasSelectedBrand => SelectedBrand != null;
        public string BrandName => SelectedBrand?.BrandName ?? "Unknown";
        public string Description => SelectedBrand?.Description ?? "Unknown";
        public string ImageBrandPath => SelectedBrand?.ImageBrandPath;

        public BrandDetails(SelectedBrandStores selectedBrandStores)
        {           
            _selectedBrandStores = selectedBrandStores;

            _selectedBrandStores.BrandStoresChanged += _selectedBrandStores_BrandStoresChanged;
        }

        protected override void Dispose()
        {
            _selectedBrandStores.BrandStoresChanged -= _selectedBrandStores_BrandStoresChanged;
            base.Dispose();
        }

        private void _selectedBrandStores_BrandStoresChanged()
        {
            OnPropertyChanged(nameof(BrandName));
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(ImageBrandPath));
        }
    }
}
