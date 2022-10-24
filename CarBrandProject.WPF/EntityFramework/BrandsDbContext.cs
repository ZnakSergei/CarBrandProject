using CarBrandProject.WPF.EntityFramework.DTOs;
using CarBrandProject.WPF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.EntityFramework
{
    public class BrandsDbContext : DbContext
    {
        public BrandsDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BrandDto> Brands { get; set; }
    }
}
