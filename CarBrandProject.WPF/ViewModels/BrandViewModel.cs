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
    public class BrandViewModel : BaseViewModel
    {
        public ObservableCollection<BrandItemListing> Brands {get;set;}
        public ObservableCollection<ModelsModel> Models {get;set;}
        

        private readonly SelectedBrandStores _selectedBrandStores;

        private BrandItemListing _selectedBrand;
        
        public BrandItemListing SelectedBrand
        {
            get { return _selectedBrand; }
            set
            {
                _selectedBrand = value;
                OnPropertyChanged(nameof(SelectedBrand));

                _selectedBrandStores.BrandStore = _selectedBrand.BrandModel;

            }
        }

        public BrandViewModel(SelectedBrandStores selectedBrandStores)
        {
            Brands = new ObservableCollection<BrandItemListing>();

            Brands.Add(new BrandItemListing(new BrandModel() { BrandName = "Brand1", Description = "Brand1Description", 
                ImageBrandPath = "D:/VS2022 Projects/Lastry/CarBrandProject/CarBrandProject.WPF/BrandIcons/Audi_Icon.png" }));
            Brands.Add(new BrandItemListing(new BrandModel() { BrandName = "Brand2", Description = "Brand2Description", 
                ImageBrandPath = "D:/VS2022 Projects/Lastry/CarBrandProject/CarBrandProject.WPF/BrandIcons/BMW_Icon.jpg" }));
            Brands.Add(new BrandItemListing(new BrandModel() { BrandName = "Brand3", Description = "Brand3Description",
                ImageBrandPath = "D:/VS2022 Projects/Lastry/CarBrandProject/CarBrandProject.WPF/BrandIcons/VW_Icon.jpg" }));
            _selectedBrandStores = selectedBrandStores;
        }
    }

    public class BrandItemListing : BaseViewModel
    {
        public BrandModel BrandModel { get; set; }

        public string BrandName => BrandModel.BrandName;

        public BrandItemListing(BrandModel brandModel)
        {
            BrandModel = brandModel;
        }
    }

    public class BrandDetails : BaseViewModel
    {
        private readonly SelectedBrandStores _selectedBrandStores;
        private BrandModel SelectedBrand => _selectedBrandStores.BrandStore;
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
