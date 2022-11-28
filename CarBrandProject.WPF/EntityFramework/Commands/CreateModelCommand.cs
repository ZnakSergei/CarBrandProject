using CarBrandProject.WPF.Commands;
using CarBrandProject.WPF.EntityFramework.DTOs;
using CarBrandProject.WPF.Models;
using CarBrandProject.WPF.Stores;
using System.Linq;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.EntityFramework.Commands
{
    public class CreateModelCommand : ICreateModelCommand
    {
        private readonly BrandsDbContextFactory _brandsDbContextFactory;

        public CreateModelCommand(BrandsDbContextFactory brandsDbContextFactory)
        {
            _brandsDbContextFactory = brandsDbContextFactory;
        }

        public async Task Execute(ModelsModel modelsModel)
        {
            using (var context = _brandsDbContextFactory.Create())
            {
                ModelDto modelDto = new ModelDto()
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

                context.Models.Add(modelDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
