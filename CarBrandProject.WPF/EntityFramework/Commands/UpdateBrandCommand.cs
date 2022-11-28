using CarBrandProject.WPF.Commands;
using CarBrandProject.WPF.EntityFramework.DTOs;
using CarBrandProject.WPF.Models;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.EntityFramework.Commands
{
    internal class UpdateBrandCommand : IUpdateBrandCommand
    {
        private readonly BrandsDbContextFactory _brandsContextFactory;
        public UpdateBrandCommand(BrandsDbContextFactory brandsContextFactory)
        {
            _brandsContextFactory = brandsContextFactory;
        }

        public async Task Execute(BrandModel brandModel)
        {
            using (BrandsDbContext context = _brandsContextFactory.Create())
            {
                BrandDto brandDto = new BrandDto()
                {
                    BrandId = brandModel.Id,
                    BrandName = brandModel.BrandName,
                    Description = brandModel.Description,
                    ImagePath = brandModel.ImageBrandPath
                };

                context.Brands.Update(brandDto);

                await context.SaveChangesAsync();
            }
        }
    }
}
