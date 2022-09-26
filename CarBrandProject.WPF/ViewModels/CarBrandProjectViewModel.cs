using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.ViewModels
{
    public class CarBrandProjectViewModel : BaseViewModel
    {
        public BrandViewModel BrandViewModel { get; set; }
        public BrandItemViewModel BrandItemViewModel { get; set; }

        public CarBrandProjectViewModel()
        {
            BrandViewModel = new BrandViewModel();
            BrandItemViewModel = new BrandItemViewModel();
        }
    }
}
