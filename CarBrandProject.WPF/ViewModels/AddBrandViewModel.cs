using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.ViewModels
{
    public class AddBrandViewModel : BaseViewModel
    {
        public BrandDetailsFormViewModel BrandDetailsFormViewModel { get; set; }
        public AddBrandViewModel()
        {
            BrandDetailsFormViewModel = new BrandDetailsFormViewModel();
        }

    }
}
