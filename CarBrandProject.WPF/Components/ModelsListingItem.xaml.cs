using System.Windows;
using System.Windows.Controls;

namespace CarBrandProject.WPF.Components
{
    /// <summary>
    /// Interaction logic for ModelsListingItem.xaml
    /// </summary>
    public partial class ModelsListingItem : UserControl
    {
        public ModelsListingItem()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dropdownModels.IsOpen = false;
        }
    }
}
