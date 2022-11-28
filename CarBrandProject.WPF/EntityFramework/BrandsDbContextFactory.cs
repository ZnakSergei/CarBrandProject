using Microsoft.EntityFrameworkCore;

namespace CarBrandProject.WPF.EntityFramework
{
    public class BrandsDbContextFactory 
    {
        private readonly DbContextOptions _option;

        public BrandsDbContextFactory(DbContextOptions option)
        {
           
            _option = option;
        }

        public BrandsDbContext Create()
        {          
            return new BrandsDbContext(_option);
        }
    }
}
