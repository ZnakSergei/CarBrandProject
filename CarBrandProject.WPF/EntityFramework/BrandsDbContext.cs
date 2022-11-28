using CarBrandProject.WPF.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CarBrandProject.WPF.EntityFramework
{
    public class BrandsDbContext : DbContext
    {
        public BrandsDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BrandDto> Brands { get; set; }
        public DbSet<ModelDto> Models { get; set; }

    }
}
