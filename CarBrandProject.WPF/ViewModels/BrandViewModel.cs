﻿using CarBrandProject.WPF.Commands;
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

        private ModelsModel _model;

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

        public BrandViewModel(SelectedBrandStores selectedBrandStores, SelectedModelStores selectedModelStores, ModalNavigationStore modalNavigationStore)
        {
            Brands = new ObservableCollection<BrandItemListing>();
            Models = new ObservableCollection<ModelListingItemViewModel>();

            AddBrand(new BrandModel()
            {
                BrandName = "Brand1",
                Description = "Brand1Description",
                ImageBrandPath = "D:/VS2022 Projects/Lastry/CarBrandProject/CarBrandProject.WPF/BrandIcons/Audi_Icon.png",
                BrandModels = new ObservableCollection<ModelListingItemViewModel>
                    {
                            new ModelListingItemViewModel (_model = new ModelsModel()
                        {
                            ModelName = "Brand1Model1",
                            TypeOfFuel = "Gas",
                            DateOnMarket = "12.11.2012",
                            ModelClass = "Family car",
                            Price = 12000,
                            PassangerCapacity = 5,
                            IsAvalable = true
                        }, EditModelCommand = new OpenEditModelCommand(_model, modalNavigationStore)),
                            new ModelListingItemViewModel (_model = new ModelsModel()
                        {
                            ModelName = "Brand1Model2",
                            TypeOfFuel = "Gas",
                            DateOnMarket = "12.11.2012",
                            ModelClass = "Family car",
                            Price = 12000,
                            PassangerCapacity = 5,
                            IsAvalable = true
                        }, EditModelCommand = new OpenEditModelCommand(_model, modalNavigationStore)),
                            new ModelListingItemViewModel (_model = new ModelsModel()
                        {
                            ModelName = "Brand1Model3",
                            TypeOfFuel = "Gas",
                            DateOnMarket = "12.11.2012",
                            ModelClass = "Family car",
                            Price = 12000,
                            PassangerCapacity = 5,
                            IsAvalable = true
                         }, EditModelCommand = new OpenEditModelCommand(_model, modalNavigationStore))
                    }
            }, modalNavigationStore);

            AddBrand(new BrandModel()
            {
                BrandName = "Brand2",
                Description = "Brand2Description",
                ImageBrandPath = "D:/VS2022 Projects/Lastry/CarBrandProject/CarBrandProject.WPF/BrandIcons/BMW_Icon.jpg",
                BrandModels = new ObservableCollection<ModelListingItemViewModel>
                    {
                            new ModelListingItemViewModel (_model = new ModelsModel()
                        {
                            ModelName = "Brand2Model1",
                            TypeOfFuel = "Gas",
                            DateOnMarket = "12.11.2012",
                            ModelClass = "Family car",
                            Price = 12000,
                            PassangerCapacity = 5,
                            IsAvalable = true
                        }, EditModelCommand = new OpenEditModelCommand(_model, modalNavigationStore)),
                            new ModelListingItemViewModel (_model = new ModelsModel()
                        {
                            ModelName = "Brand2Model2",
                            TypeOfFuel = "Gas",
                            DateOnMarket = "12.11.2012",
                            ModelClass = "Family car",
                            Price = 12000,
                            PassangerCapacity = 5,
                            IsAvalable = true
                        }, EditModelCommand = new OpenEditModelCommand(_model, modalNavigationStore)),
                            new ModelListingItemViewModel (_model = new ModelsModel()
                        {
                            ModelName = "Brand2Model3",
                            TypeOfFuel = "Gas",
                            DateOnMarket = "12.11.2012",
                            ModelClass = "Family car",
                            Price = 12000,
                            PassangerCapacity = 5,
                            IsAvalable = true
                         }, EditModelCommand = new OpenEditModelCommand(_model, modalNavigationStore))
                    }
            }, modalNavigationStore);

            AddBrand(new BrandModel()
            {
                BrandName = "Brand3",
                Description = "Brand3Description",
                    ImageBrandPath = "D:/VS2022 Projects/Lastry/CarBrandProject/CarBrandProject.WPF/BrandIcons/VW_Icon.jpg",
                    BrandModels = new ObservableCollection<ModelListingItemViewModel>
                    {
                            new ModelListingItemViewModel (_model = new ModelsModel()
                        {
                            ModelName = "Brand3Model1",
                            TypeOfFuel = "Gas",
                            DateOnMarket = "12.11.2012",
                            ModelClass = "Family car",
                            Price = 12000,
                            PassangerCapacity = 5,
                            IsAvalable = true
                        }, EditModelCommand = new OpenEditModelCommand(_model, modalNavigationStore)),
                            new ModelListingItemViewModel (_model = new ModelsModel()
                        {
                            ModelName = "Brand3Model2",
                            TypeOfFuel = "Gas",
                            DateOnMarket = "12.11.2012",
                            ModelClass = "Family car",
                            Price = 12000,
                            PassangerCapacity = 5,
                            IsAvalable = true
                        }, EditModelCommand = new OpenEditModelCommand(_model, modalNavigationStore)),
                            new ModelListingItemViewModel (_model = new ModelsModel()
                        {
                            ModelName = "Brand3Model3",
                            TypeOfFuel = "Gas",
                            DateOnMarket = "12.11.2012",
                            ModelClass = "Family car",
                            Price = 12000,
                            PassangerCapacity = 5,
                            IsAvalable = true
                         }, EditModelCommand = new OpenEditModelCommand(_model, modalNavigationStore))
                        
                    }
            }, modalNavigationStore);
            //Brands.Add(new BrandItemListing(new BrandModel()
            //{
            //    BrandName = "Brand1",
            //    Description = "Brand1Description",
            //    ImageBrandPath = "D:/VS2022 Projects/Lastry/CarBrandProject/CarBrandProject.WPF/BrandIcons/Audi_Icon.png",
            //    BrandModels = new ObservableCollection<ModelListingItemViewModel>
            //    {
            //            new ModelListingItemViewModel (new ModelsModel()
            //        {
            //            ModelName = "Brand1Model1",
            //            TypeOfFuel = "Gas",
            //            DateOnMarket = "12.11.2012",
            //            ModelClass = "Family car",
            //            Price = 12000,
            //            PassangerCapacity = 5,
            //            IsAvalable = true
            //        }),
            //            new ModelListingItemViewModel (new ModelsModel()
            //        {
            //            ModelName = "Brand1Model2",
            //            TypeOfFuel = "Gas",
            //            DateOnMarket = "12.11.2012",
            //            ModelClass = "Family car",
            //            Price = 12000,
            //            PassangerCapacity = 5,
            //            IsAvalable = true
            //        }),
            //            new ModelListingItemViewModel (new ModelsModel()
            //        {
            //            ModelName = "Brand1Model3",
            //            TypeOfFuel = "Gas",
            //            DateOnMarket = "12.11.2012",
            //            ModelClass = "Family car",
            //            Price = 12000,
            //            PassangerCapacity = 5,
            //            IsAvalable = true
            //         })
            //    }
            //}));

            //Brands.Add(new BrandItemListing(new BrandModel() { BrandName = "Brand2", Description = "Brand2Description", 
            //    ImageBrandPath = "D:/VS2022 Projects/Lastry/CarBrandProject/CarBrandProject.WPF/BrandIcons/BMW_Icon.jpg",
            //    BrandModels = new ObservableCollection<ModelListingItemViewModel>
            //    {
            //            new ModelListingItemViewModel (new ModelsModel()
            //        {
            //            ModelName = "Brand2Model1",
            //            TypeOfFuel = "Gas",
            //            DateOnMarket = "12.11.2012",
            //            ModelClass = "Family car",
            //            Price = 12000,
            //            PassangerCapacity = 5,
            //            IsAvalable = true
            //        }),
            //            new ModelListingItemViewModel (new ModelsModel()
            //        {
            //            ModelName = "Brand2Model2",
            //            TypeOfFuel = "Gas",
            //            DateOnMarket = "12.11.2012",
            //            ModelClass = "Family car",
            //            Price = 12000,
            //            PassangerCapacity = 5,
            //            IsAvalable = true
            //        }),
            //            new ModelListingItemViewModel (new ModelsModel()
            //        {
            //            ModelName = "Brand2Model3",
            //            TypeOfFuel = "Gas",
            //            DateOnMarket = "12.11.2012",
            //            ModelClass = "Family car",
            //            Price = 12000,
            //            PassangerCapacity = 5,
            //            IsAvalable = true
            //         })
            //    }
            //}));

            //Brands.Add(new BrandItemListing(new BrandModel() { BrandName = "Brand3", Description = "Brand3Description",
            //    ImageBrandPath = "D:/VS2022 Projects/Lastry/CarBrandProject/CarBrandProject.WPF/BrandIcons/VW_Icon.jpg",
            //    BrandModels = new ObservableCollection<ModelListingItemViewModel>
            //    {
            //            new ModelListingItemViewModel (new ModelsModel()
            //        {
            //            ModelName = "Brand3Model1",
            //            TypeOfFuel = "Gas",
            //            DateOnMarket = "12.11.2012",
            //            ModelClass = "Family car",
            //            Price = 12000,
            //            PassangerCapacity = 5,
            //            IsAvalable = true
            //        }),
            //            new ModelListingItemViewModel (new ModelsModel()
            //        {
            //            ModelName = "Brand3Model2",
            //            TypeOfFuel = "Gas",
            //            DateOnMarket = "12.11.2012",
            //            ModelClass = "Family car",
            //            Price = 12000,
            //            PassangerCapacity = 5,
            //            IsAvalable = true
            //        }),
            //            new ModelListingItemViewModel (new ModelsModel()
            //        {
            //            ModelName = "Brand3Model3",
            //            TypeOfFuel = "Gas",
            //            DateOnMarket = "12.11.2012",
            //            ModelClass = "Family car",
            //            Price = 12000,
            //            PassangerCapacity = 5,
            //            IsAvalable = true
            //         })
            //    }
            //}));
            _selectedBrandStores = selectedBrandStores;
            _selectedModelStores = selectedModelStores;

            AddBrandCommand = new OpenAddBrandCommand(modalNavigationStore);
            AddModelCommand = new OpenAddModelCommand(modalNavigationStore);
        }

        private void AddBrand(BrandModel brandModel, ModalNavigationStore modalNavigation)
        {
            ICommand editCommand = new OpenEditBrandCommand(brandModel, modalNavigation);
            Brands.Add(new BrandItemListing(brandModel, editCommand));
        }
    }

    public class BrandItemListing : BaseViewModel
    {
        public BrandModel BrandModel { get; set; }

        public string BrandName => BrandModel.BrandName;

        public ICommand EditBrandCommand { get; set; }
        public ICommand DeleteBrandCommand { get; set; }
        public BrandItemListing(BrandModel brandModel, ICommand editBrandCommand)
        {
            BrandModel = brandModel;
            EditBrandCommand = editBrandCommand;
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
