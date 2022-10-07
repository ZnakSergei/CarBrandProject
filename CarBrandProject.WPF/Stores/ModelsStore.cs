using CarBrandProject.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Stores
{
    public class ModelsStore
    {
        public event Action<ModelsModel> ModelAdded;

        public async Task Add(ModelsModel modelsModel)
        {
            ModelAdded?.Invoke(modelsModel);
        }
    }
}
