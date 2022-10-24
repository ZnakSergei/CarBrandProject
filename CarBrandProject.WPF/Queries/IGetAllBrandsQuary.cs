using CarBrandProject.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Queries
{
    public interface IGetAllBrandsQuary
    {
        Task<IEnumerable<BrandModel>> Execute();
    }
}
