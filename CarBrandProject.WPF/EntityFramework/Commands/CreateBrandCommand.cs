using CarBrandProject.WPF.Commands;
using CarBrandProject.WPF.EntityFramework.DTOs;
using CarBrandProject.WPF.Models;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.EntityFramework.Commands
{
    public class CreateBrandCommand : ICreateBrandCommand
    {
        private readonly BrandsDbContextFactory _brandsContextFactory;
        public CreateBrandCommand(BrandsDbContextFactory brandsContextFactory)
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

                context.Brands.Add(brandDto);

                await context.SaveChangesAsync();
            }
        }
    }
}
