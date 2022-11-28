using CarBrandProject.WPF.Commands;
using CarBrandProject.WPF.EntityFramework.DTOs;
using System;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.EntityFramework.Commands
{
    public class DeleteModelCommand : IDeleteModelCommand
    {
        BrandsDbContextFactory _brandsDbContextFactory;

        public DeleteModelCommand(BrandsDbContextFactory brandsDbContextFactory)
        {
            _brandsDbContextFactory = brandsDbContextFactory;
        }

        public async Task Execute(Guid modelId)
        {
            using (var context = _brandsDbContextFactory.Create())
            {
                ModelDto modelDto = new ModelDto()
                {
                    ModelId = modelId,
                };

                context.Models.Remove(modelDto);

                await context.SaveChangesAsync();
            }
        }
    }
}
