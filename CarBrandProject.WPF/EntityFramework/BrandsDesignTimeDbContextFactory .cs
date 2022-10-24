using CarBrandProject.WPF.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
