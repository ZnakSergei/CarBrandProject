using CarBrandProject.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Models
{
    public class BrandModel
    {
        public string BrandName { get; set; }
        public string Description { get; set; }
        public string ImageBrandPath { get; set; }

        public ObservableCollection<ModelListingItemViewModel> BrandModels { get; set; }
    }
}
