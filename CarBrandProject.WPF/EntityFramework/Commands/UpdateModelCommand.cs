using CarBrandProject.WPF.Commands;
using CarBrandProject.WPF.EntityFramework.DTOs;
using CarBrandProject.WPF.Models;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.EntityFramework.Commands
{
    public class UpdateModelCommand : IUpdateModelCommand
    {
        private BrandsDbContextFactory _brandsDbContextFactory;

        public UpdateModelCommand(BrandsDbContextFactory brandsDbContextFactory)
        {
            _brandsDbContextFactory = brandsDbContextFactory;
        }

        public async Task Execute(ModelsModel modelsModel)
        {
            using (var context = _brandsDbContextFactory.Create())
            {
                ModelDto model = new ModelDto()
                {
                    ModelId = modelsModel.ModelId,
                    ModelName = modelsModel.ModelName,
                    TypeOfFuel = modelsModel.TypeOfFuel,
                    DateOnMarket = modelsModel.DateOnMarket,
                    ModelClass = modelsModel.ModelClass,
                    Price = modelsModel.Price,
                    PassangerCapacity = modelsModel.PassangerCapacity,
                    IsAvalable = modelsModel.IsAvalable
                };

                context.Models.Update(model);

                await context.SaveChangesAsync(); 
            }
        }
    }
}
