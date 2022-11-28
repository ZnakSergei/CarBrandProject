using CarBrandProject.WPF.EntityFramework.DTOs;
using CarBrandProject.WPF.Models;
using CarBrandProject.WPF.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.EntityFramework.Queries
{
    public class GetAllBrandsQuery : IGetAllBrandsQuery
    {
        private readonly BrandsDbContextFactory _brandsContextFactory;
        public GetAllBrandsQuery(BrandsDbContextFactory brandsContextFactory)
        {
            _brandsContextFactory = brandsContextFactory;
        }

        public async Task<IEnumerable<BrandModel>> Execute()
        {
            using(BrandsDbContext context = _brandsContextFactory.Create())
            {
                IEnumerable<BrandDto> brandDtos = await context.Brands.ToListAsync();
                
                //TODO: Add brand models
                return brandDtos.Select(b => new BrandModel(b.BrandId, b.BrandName, b.Description, b.ImagePath, null));
            }
        }
    }
}
