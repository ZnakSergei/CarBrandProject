using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace CarBrandProject.WPF.Components
{
    /// <summary>
    /// Interaction logic for BrandDetailsForm.xaml
    /// </summary>
    public partial class BrandDetailsForm : UserControl
    {
        public BrandDetailsForm()
        {
            InitializeComponent();
        }

        private void SelPicButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics| *.jpg; *.jpeg; *.png | " +
               "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
               "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                imagePath.Text = op.FileName;
            }
        }
    }
}
