using CarBrandProject.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Stores
{
    public class SelectedModelStores
    {
        private ModelsModel _modelStore;
        public ModelsModel ModelStore
        {
            get { return _modelStore; }
            set
            {
                _modelStore = value;
                SelectedModelChanged?.Invoke();
            }
        }

        public event Action SelectedModelChanged;
    }
}
