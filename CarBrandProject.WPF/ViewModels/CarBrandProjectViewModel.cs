﻿using CarBrandProject.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.ViewModels
{
    public class CarBrandProjectViewModel : BaseViewModel
    {
        public BrandViewModel BrandViewModel { get; set; }
        public BrandDetails BrandDetailsViewModel { get; set; }
        public ModelsViewModel ModelsViewModel { get; set; }
        public ModelDetails ModelDetails { get; set; }

        public CarBrandProjectViewModel(SelectedBrandStores _selectedBrandStores, SelectedModelStores _selectedModelStores)
        {
            BrandViewModel = new BrandViewModel(_selectedBrandStores, _selectedModelStores);
            BrandDetailsViewModel = new BrandDetails(_selectedBrandStores);
            ModelsViewModel = new ModelsViewModel(_selectedModelStores);
            ModelDetails = new ModelDetails(_selectedModelStores);
        }
    }
}
