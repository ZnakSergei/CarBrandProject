using CarBrandProject.WPF.Models;
using CarBrandProject.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarBrandProject.WPF.Components
{
    /// <summary>
    /// Interaction logic for ModelsListingItem.xaml
    /// </summary>
    public partial class ModelsListingItem : UserControl
    {
        private ModelsModel modelsModel;
        private ModelsStore modelsStore;
        private ModalNavigationStore modalNavigationStore;

        public ModelsListingItem()
        {
            InitializeComponent();
        }

        public ModelsListingItem(ModelsModel modelsModel, ModelsStore modelsStore, ModalNavigationStore modalNavigationStore)
        {
            this.modelsModel = modelsModel;
            this.modelsStore = modelsStore;
            this.modalNavigationStore = modalNavigationStore;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dropdownModels.IsOpen = false;
        }
    }
}
