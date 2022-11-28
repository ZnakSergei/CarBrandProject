using CarBrandProject.WPF.ViewModels;
using System;

namespace CarBrandProject.WPF.Stores
{
    public class ModalNavigationStore
    {
        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get 
            { 
                return _currentViewModel;
            }
            set 
            { 
                _currentViewModel = value;
                CurrentViewModelChanged?.Invoke();
            }
        }

        public bool IsOpen => CurrentViewModel != null;

        public event Action CurrentViewModelChanged;

        public void Close()
        {
            CurrentViewModel = null;
        }
    }
}
