using CarBrandProject.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Commands
{
    public class LoadBrandCommand : AsyncBaseCommand
    {
        private readonly BrandsStores _brandsStores;

        public LoadBrandCommand(BrandsStores brandsStores)
        {
            _brandsStores = brandsStores;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _brandsStores.Load();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
