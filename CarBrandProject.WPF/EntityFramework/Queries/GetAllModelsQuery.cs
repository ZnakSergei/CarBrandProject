using CarBrandProject.WPF.EntityFramework.DTOs;
using CarBrandProject.WPF.Models;
using CarBrandProject.WPF.Queries;
using CarBrandProject.WPF.Stores;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.EntityFramework.Queries
{
    public class GetAllModelsQuery : IGetAllModelsQuary
    {
        private readonly BrandsDbContextFactory _brandsDbContextFactory;
        

        public GetAllModelsQuery(BrandsDbContextFactory brandsDbContextFactory)
        {
            _brandsDbContextFactory = brandsDbContextFactory;
        }

        public async Task<IEnumerable<ModelsModel>> Execute()
        {
            using (BrandsDbContext context = _brandsDbContextFactory.Create())
            {
                IEnumerable<ModelDto> modelDto = await context.Models.ToListAsync();

                return modelDto?.Select(m => new ModelsModel(m.ModelId, m.ModelName, m.TypeOfFuel, m.DateOnMarket, m.ModelClass, m.Price, m.PassangerCapacity, m.IsAvalable));
            }
        }
    }
}
