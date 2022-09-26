using CarBrandProject.WPF.Models;
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
        public ObservableCollection<BrandItemViewModel> Brands {get;set;}
        public ObservableCollection<ModelsModel> Models {get;set;}

        private BrandModel _selectedBrand;

        public BrandModel SelectedBrand
        {
            get { return _selectedBrand; }
            set
            {
                _selectedBrand = value;
                OnPropertyChanged(nameof(SelectedBrand));
            }
        }

        public BrandViewModel()
        {

            Brands = new ObservableCollection<BrandItemViewModel>();
            Models = new ObservableCollection<ModelsModel>();
                
        }
    }

    public class BrandItemViewModel : BaseViewModel
    {
        public string BrandName { get; set; }
        public string BrandDescription { get; set; }

        public BrandItemViewModel()
        {
            BrandName = "Brand1";
            BrandDescription = "DescriptionBrand1";
        }

    }
}
