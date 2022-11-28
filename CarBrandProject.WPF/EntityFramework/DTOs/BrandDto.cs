using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarBrandProject.WPF.EntityFramework.DTOs
{
    public class BrandDto
    {
        [Key]
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public string? ImagePath { get; set; }
        
    }
}
