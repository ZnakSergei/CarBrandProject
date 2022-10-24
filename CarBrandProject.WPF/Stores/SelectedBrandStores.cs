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
        private readonly BrandsStores _brandsStores;

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

        public SelectedBrandStores(BrandsStores brandsStores)
        {
            _brandsStores = brandsStores;

            _brandsStores.BrandEdited += _brandsStores_BrandEdited;
            _brandsStores.BrandDeleted += _brandsStores_BrandDeleted;
        }

        private void _brandsStores_BrandDeleted(Guid brandId)
        {
            if (brandId == BrandStore?.Id)
            {
                BrandStore = null;
            }
        }

        private void _brandsStores_BrandEdited(BrandModel brandModel)
        {
            if (brandModel.Id == BrandStore?.Id)
            {
                BrandStore = brandModel;
            }
        }
    }
}
