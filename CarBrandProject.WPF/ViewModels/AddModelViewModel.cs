using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.ViewModels
{
    public class AddModelViewModel : BaseViewModel
    {
        public ModelDetailsFormViewModel ModelDetailsFormViewModel { get; set; }

        public AddModelViewModel()
        {
            ModelDetailsFormViewModel = new ModelDetailsFormViewModel();
        }
    }
}
