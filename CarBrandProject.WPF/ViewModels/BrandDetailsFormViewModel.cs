using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarBrandProject.WPF.ViewModels
{
    public class BrandDetailsFormViewModel : BaseViewModel
    {
        private string _brandName;
        public string BrandName
        {
            get { return _brandName; }
            set
            {
                _brandName = value;
                OnPropertyChanged(nameof(BrandName));
            }
        }

        private string _brandDescription;
        public string BrandDescription
        {
            get { return _brandDescription; }
            set
            {
                _brandDescription = value;
                OnPropertyChanged(nameof(BrandDescription));
            }
        }

        private string _imagePath;
        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }

        public ICommand SubmitBrandCommand { get; set; }
        public ICommand CancelBrandCommand { get; set; }
    }
}
