using CarBrandProject.WPF.Commands;
using CarBrandProject.WPF.EntityFramework.DTOs;
using System;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.EntityFramework.Commands
{
    public class DeleteBrandCommand : IDeleteBrandCommand
    {
        private readonly BrandsDbContextFactory _brandsContextFactory;
        public DeleteBrandCommand(BrandsDbContextFactory brandsContextFactory)
        {
            _brandsContextFactory = brandsContextFactory;
        }

        public async Task Execute(Guid BrandId)
        {
            using (BrandsDbContext context = _brandsContextFactory.Create())
            {
                BrandDto brandDto = new BrandDto()
                {
                    BrandId = BrandId,
                };

                context.Brands.Remove(brandDto);

                await context.SaveChangesAsync();
            }
        }
    }
}
