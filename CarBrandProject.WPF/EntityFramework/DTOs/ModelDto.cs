using System;
using System.ComponentModel.DataAnnotations;

namespace CarBrandProject.WPF.EntityFramework.DTOs
{
    public class ModelDto
    {
        [Key]
        public Guid ModelId { get; set; }
        public string ModelName { get; set; }
        public string TypeOfFuel { get; set; }
        public string DateOnMarket { get; set; }
        public string ModelClass { get; set; }
        public int Price { get; set; }
        public int PassangerCapacity { get; set; }
        public bool IsAvalable { get; set; }
        
    }
}
