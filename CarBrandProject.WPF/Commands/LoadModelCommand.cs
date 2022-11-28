using CarBrandProject.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Commands
{
    public class LoadModelCommand : AsyncBaseCommand
    {
        private readonly ModelsStore _modelsStore;

        public LoadModelCommand(ModelsStore modelsStore)
        {
            _modelsStore = modelsStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _modelsStore.Load();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
