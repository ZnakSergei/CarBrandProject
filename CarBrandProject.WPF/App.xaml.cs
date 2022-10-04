using CarBrandProject.WPF.Stores;
using CarBrandProject.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CarBrandProject.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly SelectedBrandStores _selectedBrandStores;
        private readonly SelectedModelStores _selectedModelStores;

        private readonly ModalNavigationStore _modalNavigationStore;

        public App()
        {
            _selectedBrandStores = new SelectedBrandStores();
            _selectedModelStores = new SelectedModelStores();

            _modalNavigationStore = new ModalNavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore, new CarBrandProjectViewModel(_selectedBrandStores, _selectedModelStores))
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
