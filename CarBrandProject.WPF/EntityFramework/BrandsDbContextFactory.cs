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
