using CarBrandProject.WPF.Commands;
using CarBrandProject.WPF.Components;
using CarBrandProject.WPF.Models;
using CarBrandProject.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
        public ICommand EditModelCommand { get; set; }

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

            //AddBrand(new BrandModel()
            //{
            //    BrandName = "Brand1",
            //    Description = "Brand1Description",
            //    ImageBrandPath = "D:/VS2022 Projects/Lastry/CarBrandProject/CarBrandProject.WPF/BrandIcons/Audi_Icon.png",
            //    BrandModels = new ObservableCollection<ModelListingItemViewModel>
            //        {
            //                new ModelListingItemViewModel (_model = new ModelsModel()
            //            {
            //                ModelName = "Brand1Model1",
            //                TypeOfFuel = "Gas",
            //                DateOnMarket = "12.11.2012",
            //                ModelClass = "Family car",
            //                Price = 12000,
            //                PassangerCapacity = 5,
            //                IsAvalable = true
            //            }, EditModelCommand = new OpenEditModelCommand(_model, modalNavigationStore)),

            //                new ModelListingItemViewModel (_model = new ModelsModel()
            //            {
            //                ModelName = "Brand1Model2",
            //                TypeOfFuel = "Gas",
            //                DateOnMarket = "12.11.2012",
            //                ModelClass = "Family car",
            //                Price = 12000,
            //                PassangerCapacity = 5,
            //                IsAvalable = true
            //            }, EditModelCommand = new OpenEditModelCommand(_model, modalNavigationStore)),

            //                new ModelListingItemViewModel (_model = new ModelsModel()
            //            {
            //                ModelName = "Brand1Model3",
            //                TypeOfFuel = "Gas",
            //                DateOnMarket = "12.11.2012",
            //                ModelClass = "Family car",
            //                Price = 12000,
            //                PassangerCapacity = 5,
            //                IsAvalable = true
            //             }, EditModelCommand = new OpenEditModelCommand(_model, modalNavigationStore))
            //        }
            //}, modalNavigationStore);

            //AddBrand(new BrandModel()
            //{
            //    BrandName = "Brand2",
            //    Description = "Brand2Description",
            //    ImageBrandPath = "D:/VS2022 Projects/Lastry/CarBrandProject/CarBrandProject.WPF/BrandIcons/BMW_Icon.jpg",
            //    BrandModels = new ObservableCollection<ModelListingItemViewModel>
            //        {
            //                new ModelListingItemViewModel (_model = new ModelsModel()
            //            {
            //                ModelName = "Brand2Model1",
            //                TypeOfFuel = "Gas",
            //                DateOnMarket = "12.11.2012",
            //                ModelClass = "Family car",
            //                Price = 12000,
            //                PassangerCapacity = 5,
            //                IsAvalable = true
            //            }, EditModelCommand = new OpenEditModelCommand(_model, modalNavigationStore)),

            //                new ModelListingItemViewModel (_model = new ModelsModel()
            //            {
            //                ModelName = "Brand2Model2",
            //                TypeOfFuel = "Gas",
            //                DateOnMarket = "12.11.2012",
            //                ModelClass = "Family car",
            //                Price = 12000,
            //                PassangerCapacity = 5,
            //                IsAvalable = true
            //            }, EditModelCommand = new OpenEditModelCommand(_model, modalNavigationStore)),

            //                new ModelListingItemViewModel (_model = new ModelsModel()
            //            {
            //                ModelName = "Brand2Model3",
            //                TypeOfFuel = "Gas",
            //                DateOnMarket = "12.11.2012",
            //                ModelClass = "Family car",
            //                Price = 12000,
            //                PassangerCapacity = 5,
            //                IsAvalable = true
            //             }, EditModelCommand = new OpenEditModelCommand(_model, modalNavigationStore))
            //        }
            //}, modalNavigationStore);

            //AddBrand(new BrandModel()
            //{
            //    BrandName = "Brand3",
            //    Description = "Brand3Description",
            //        ImageBrandPath = "D:/VS2022 Projects/Lastry/CarBrandProject/CarBrandProject.WPF/BrandIcons/VW_Icon.jpg",
            //        BrandModels = new ObservableCollection<ModelListingItemViewModel>
            //        {
            //                new ModelListingItemViewModel (_model = new ModelsModel()
            //            {
            //                ModelName = "Brand3Model1",
            //                TypeOfFuel = "Gas",
            //                DateOnMarket = "12.11.2012",
            //                ModelClass = "Family car",
            //                Price = 12000,
            //                PassangerCapacity = 5,
            //                IsAvalable = true
            //            }, EditModelCommand = new OpenEditModelCommand(_model, modalNavigationStore)),

            //                new ModelListingItemViewModel (_model = new ModelsModel()
            //            {
            //                ModelName = "Brand3Model2",
            //                TypeOfFuel = "Gas",
            //                DateOnMarket = "12.11.2012",
            //                ModelClass = "Family car",
            //                Price = 12000,
            //                PassangerCapacity = 5,
            //                IsAvalable = true
            //            }, EditModelCommand = new OpenEditModelCommand(_model, modalNavigationStore)),

            //                new ModelListingItemViewModel (_model = new ModelsModel()
            //            {
            //                ModelName = "Brand3Model3",
            //                TypeOfFuel = "Gas",
            //                DateOnMarket = "12.11.2012",
            //                ModelClass = "Family car",
            //                Price = 12000,
            //                PassangerCapacity = 5,
            //                IsAvalable = true
            //             }, EditModelCommand = new OpenEditModelCommand(_model, modalNavigationStore))
                        
            //        }
            //}, modalNavigationStore);

            ////Brands.Add(new BrandItemListing(new BrandModel()
            ////{
            ////    BrandName = "Brand1",
            ////    Description = "Brand1Description",
            ////    ImageBrandPath = "D:/VS2022 Projects/Lastry/CarBrandProject/CarBrandProject.WPF/BrandIcons/Audi_Icon.png",
            ////    BrandModels = new ObservableCollection<ModelListingItemViewModel>
            ////    {
            ////            new ModelListingItemViewModel (new ModelsModel()
            ////        {
            ////            ModelName = "Brand1Model1",
            ////            TypeOfFuel = "Gas",
            ////            DateOnMarket = "12.11.2012",
            ////            ModelClass = "Family car",
            ////            Price = 12000,
            ////            PassangerCapacity = 5,
            ////            IsAvalable = true
            ////        }),
            ////            new ModelListingItemViewModel (new ModelsModel()
            ////        {
            ////            ModelName = "Brand1Model2",
            ////            TypeOfFuel = "Gas",
            ////            DateOnMarket = "12.11.2012",
            ////            ModelClass = "Family car",
            ////            Price = 12000,
            ////            PassangerCapacity = 5,
            ////            IsAvalable = true
            ////        }),
            ////            new ModelListingItemViewModel (new ModelsModel()
            ////        {
            ////            ModelName = "Brand1Model3",
            ////            TypeOfFuel = "Gas",
            ////            DateOnMarket = "12.11.2012",
            ////            ModelClass = "Family car",
            ////            Price = 12000,
            ////            PassangerCapacity = 5,
            ////            IsAvalable = true
            ////         })
            ////    }
            ////}));

            ////Brands.Add(new BrandItemListing(new BrandModel()
            ////{
            ////    BrandName = "Brand2",
            ////    Description = "Brand2Description",
            ////    ImageBrandPath = "D:/VS2022 Projects/Lastry/CarBrandProject/CarBrandProject.WPF/BrandIcons/BMW_Icon.jpg",
            ////    BrandModels = new ObservableCollection<ModelListingItemViewModel>
            ////    {
            ////            new ModelListingItemViewModel (new ModelsModel()
            ////        {
            ////            ModelName = "Brand2Model1",
            ////            TypeOfFuel = "Gas",
            ////            DateOnMarket = "12.11.2012",
            ////            ModelClass = "Family car",
            ////            Price = 12000,
            ////            PassangerCapacity = 5,
            ////            IsAvalable = true
            ////        }),
            ////            new ModelListingItemViewModel (new ModelsModel()
            ////        {
            ////            ModelName = "Brand2Model2",
            ////            TypeOfFuel = "Gas",
            ////            DateOnMarket = "12.11.2012",
            ////            ModelClass = "Family car",
            ////            Price = 12000,
            ////            PassangerCapacity = 5,
            ////            IsAvalable = true
            ////        }),
            ////            new ModelListingItemViewModel (new ModelsModel()
            ////        {
            ////            ModelName = "Brand2Model3",
            ////            TypeOfFuel = "Gas",
            ////            DateOnMarket = "12.11.2012",
            ////            ModelClass = "Family car",
            ////            Price = 12000,
            ////            PassangerCapacity = 5,
            ////            IsAvalable = true
            ////         })
            ////    }
            ////}));

            ////Brands.Add(new BrandItemListing(new BrandModel()
            ////{
            ////    BrandName = "Brand3",
            ////    Description = "Brand3Description",
            ////    ImageBrandPath = "D:/VS2022 Projects/Lastry/CarBrandProject/CarBrandProject.WPF/BrandIcons/VW_Icon.jpg",
            ////    BrandModels = new ObservableCollection<ModelListingItemViewModel>
            ////    {
            ////            new ModelListingItemViewModel (new ModelsModel()
            ////        {
            ////            ModelName = "Brand3Model1",
            ////            TypeOfFuel = "Gas",
            ////            DateOnMarket = "12.11.2012",
            ////            ModelClass = "Family car",
            ////            Price = 12000,
            ////            PassangerCapacity = 5,
            ////            IsAvalable = true
            ////        }),
            ////            new ModelListingItemViewModel (new ModelsModel()
            ////        {
            ////            ModelName = "Brand3Model2",
            ////            TypeOfFuel = "Gas",
            ////            DateOnMarket = "12.11.2012",
            ////            ModelClass = "Family car",
            ////            Price = 12000,
            ////            PassangerCapacity = 5,
            ////            IsAvalable = true
            ////        }),
            ////            new ModelListingItemViewModel (new ModelsModel()
            ////        {
            ////            ModelName = "Brand3Model3",
            ////            TypeOfFuel = "Gas",
            ////            DateOnMarket = "12.11.2012",
            ////            ModelClass = "Family car",
            ////            Price = 12000,
            ////            PassangerCapacity = 5,
            ////            IsAvalable = true
            ////         })
            ////    }
            ////}));
            _selectedBrandStores = selectedBrandStores;
            _selectedModelStores = selectedModelStores;
            _modalNavigationStore = modalNavigationStore;
            _brandsStores = brandsStores;
            _modelsStore = modelsStore;

            _brandsStores.BrandAdded += _brandsStores_BrandAdded;
            _brandsStores.BrandEdited += _brandsStores_BrandUpdated;

            _modelsStore.ModelAdded += _modelsStore_ModelAdded;

            AddBrandCommand = new OpenAddBrandCommand(brandsStores, modalNavigationStore);
            AddModelCommand = new OpenAddModelCommand(modelsStore, modalNavigationStore);
            
        }

        private void _brandsStores_BrandUpdated(BrandModel brandModel)
        {
            BrandItemListing brand = Brands.FirstOrDefault(b => b.BrandModel.Id == brandModel.Id);

            if (brand != null)
            {
                brand.Update(brandModel);
            }
        }

        private void _modelsStore_ModelAdded(ModelsModel modelsModel)
        {
            AddModels(modelsModel);
        }
        private void AddModels(ModelsModel modelsModel)
        {
            ICommand editModelCommand = new OpenEditModelCommand(modelsModel, _modalNavigationStore);
            Models.Add(new ModelListingItemViewModel(modelsModel, editModelCommand));
        }

        private void _brandsStores_BrandAdded(BrandModel brandModel)
        {
            AddBrand(brandModel);
        }
        protected override void Dispose()
        {
            _brandsStores.BrandAdded -= _brandsStores_BrandAdded;
            _brandsStores.BrandEdited += _brandsStores_BrandUpdated;

            _modelsStore.ModelAdded -= _modelsStore_ModelAdded;

            base.Dispose();
        }
        private void AddBrand(BrandModel brandModel)
        {
            BrandItemListing brandsItem = new BrandItemListing(brandModel, _brandsStores, _modalNavigationStore);
            Brands.Add(brandsItem);
        }
    }

    public class BrandItemListing : BaseViewModel
    {
        public BrandModel BrandModel { get; set; }

        public string BrandName => BrandModel.BrandName;

        public ICommand EditBrandCommand { get; set; }
        public ICommand DeleteBrandCommand { get; set; }
        
        public BrandItemListing(BrandModel brandModel, BrandsStores brandsStores, ModalNavigationStore modalNavigationStore)
        {
            BrandModel = brandModel;
            EditBrandCommand = new OpenEditBrandCommand(this, brandsStores, modalNavigationStore);
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
