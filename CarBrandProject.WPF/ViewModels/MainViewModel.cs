using CarBrandProject.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        public BaseViewModel CurrentViewModel => _modalNavigationStore.CurrentViewModel;
        public bool IsModalOpen => _modalNavigationStore.IsOpen;
        public CarBrandProjectViewModel CarBrandProjectViewModel { get; set; }
        public MainViewModel(ModalNavigationStore modalNavigationBrandStore, CarBrandProjectViewModel carBrandProjectViewModel)
        {
            _modalNavigationStore = modalNavigationBrandStore;
            CarBrandProjectViewModel = carBrandProjectViewModel;

            _modalNavigationStore.CurrentViewModelChanged += _modalNavigationStore_CurrentViewModelChanged;

            _modalNavigationStore.CurrentViewModel = new EditModelDetailsViewModel();
        }

        protected override void Dispose()
        {
            _modalNavigationStore.CurrentViewModelChanged -= _modalNavigationStore_CurrentViewModelChanged;
            base.Dispose();
        }

        private void _modalNavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }
    }
}
