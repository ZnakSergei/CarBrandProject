using CarBrandProject.WPF.Stores;

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
        public ModelDetails ModelDetails { get; set; }
        
        public CarBrandProjectViewModel(BrandsStores brandsStores, SelectedBrandStores selectedBrandStores, ModelsStore modelsStore, SelectedModelStores selectedModelStores, ModalNavigationStore modalNavigationStore)
        {
            BrandViewModel = BrandViewModel.LoadBrandViewModel(brandsStores ,selectedBrandStores, modelsStore, selectedModelStores, modalNavigationStore);
            BrandDetailsViewModel = new BrandDetails(selectedBrandStores);
            ModelDetails = new ModelDetails(selectedModelStores);
        }
    }
}
