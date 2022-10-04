using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.ViewModels
{
    public class EditBrandDetailsViewModel : BaseViewModel
    {
        public BrandDetailsFormViewModel BrandDetailsFormViewModel { get; set; }

        public EditBrandDetailsViewModel()
        {
            BrandDetailsFormViewModel = new BrandDetailsFormViewModel();
        }
    }
}
