using CarBrandProject.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Stores
{
    public class BrandsStores
    {
        public event Action<BrandModel> BrandAdded;
        public event Action<BrandModel> BrandEdited;

        public async Task Add(BrandModel brandModel)
        {
            BrandAdded?.Invoke(brandModel);
        }

        public async Task Update(BrandModel brandModel)
        {
            BrandEdited?.Invoke(brandModel);
        }
    }
}
