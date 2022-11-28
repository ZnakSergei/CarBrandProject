using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CarBrandProject.WPF.EntityFramework
{
    public class BrandsDesignTimeDbContextFactory : IDesignTimeDbContextFactory<BrandsDbContext>
    {
        public BrandsDbContext CreateDbContext(string[] args = null)
        {
            return new BrandsDbContext(new DbContextOptionsBuilder().UseSqlite("Data Source=Brands.db").Options);
        }
    }
}
