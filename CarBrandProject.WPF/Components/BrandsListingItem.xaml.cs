using System.Windows;
using System.Windows.Controls;

namespace CarBrandProject.WPF.Components
{
    /// <summary>
    /// Interaction logic for BrandsListingItem.xaml
    /// </summary>
    public partial class BrandsListingItem : UserControl
    {
        public BrandsListingItem()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dropdown.IsOpen = false;
        }
    }
}
