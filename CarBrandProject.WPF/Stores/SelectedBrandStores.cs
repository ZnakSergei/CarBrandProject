using CarBrandProject.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Stores
{
    public class SelectedBrandStores
    {
        private BrandModel _brandStores;
        public BrandModel BrandStore
        {
            get
            {
                return _brandStores;
            }
            set
            {
                _brandStores = value;
                BrandStoresChanged?.Invoke();
            }
        }

        public event Action BrandStoresChanged;
    }
}
