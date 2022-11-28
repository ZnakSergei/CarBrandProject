using CarBrandProject.WPF.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Queries
{
    public interface IGetAllModelsQuary
    {
        public Task<IEnumerable<ModelsModel>> Execute();
    }
}
