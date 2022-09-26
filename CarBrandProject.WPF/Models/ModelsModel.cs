using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Models
{
    public class ModelsModel
    {
        public string ModelName { get; set; }
        public string TypeOfFuel { get; set; }
        public string DateonMarket { get; set; }
        public string ModelClass { get; set; }
        public int Price { get; set; }
        public int PassangerCapacity { get; set; }
        public bool IsAvalable { get; set; }
    }
}
