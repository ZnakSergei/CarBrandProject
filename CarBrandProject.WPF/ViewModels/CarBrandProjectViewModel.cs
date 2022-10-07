using CarBrandProject.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarBrandProject.WPF.ViewModels
{
    public class CarBrandProjectViewModel : BaseViewModel
    {
        private BrandsStores brandsStores;
        private SelectedBrandStores selectedBrandStores;
        private SelectedModelStores selectedModelStores;
        private ModalNavigationStore modalNavigationStore;

        public BrandViewModel BrandViewModel { get; set; }
        public BrandDetails BrandDetailsViewModel { get; set; }
        //public ModelsViewModel ModelsViewModel { get; set; }
        public ModelDetails ModelDetails { get; set; }
        
        public CarBrandProjectViewModel(BrandsStores brandsStores, SelectedBrandStores selectedBrandStores, ModelsStore modelsStore, SelectedModelStores selectedModelStores, ModalNavigationStore modalNavigationStore)
        {
            BrandViewModel = new BrandViewModel(brandsStores ,selectedBrandStores, modelsStore, selectedModelStores, modalNavigationStore);
            BrandDetailsViewModel = new BrandDetails(selectedBrandStores);
            //ModelsViewModel = new ModelsViewModel(_selectedModelStores);
            ModelDetails = new ModelDetails(selectedModelStores);
        }
    }
}
