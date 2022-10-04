using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.ViewModels
{
    public class EditModelDetailsViewModel : BaseViewModel
    {
        public ModelDetailsFormViewModel ModelDetailsFormViewModel { get; set; }
        public EditModelDetailsViewModel()
        {
            ModelDetailsFormViewModel = new ModelDetailsFormViewModel();
        }
    }
}
