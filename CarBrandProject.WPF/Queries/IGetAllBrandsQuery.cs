using CarBrandProject.WPF.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Queries
{
    public interface IGetAllBrandsQuery
    {
        Task<IEnumerable<BrandModel>> Execute();
    }
}
