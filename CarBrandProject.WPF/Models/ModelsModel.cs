using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Models
{
    public class ModelsModel
    {
        public Guid ModelId { get; set; }
        public string ModelName { get; set; }
        public string TypeOfFuel { get; set; }
        public string DateOnMarket { get; set; }
        public string ModelClass { get; set; }
        public int Price { get; set; }
        public int PassangerCapacity { get; set; }
        public bool IsAvalable { get; set; }
        public ModelsModel(Guid modelId, string modelName, string typeOfFuel, string dateOnMarket, string modelClass, int price, int passangerCapacity, bool isAvalable)
        {
            ModelId = modelId;
            ModelName = modelName;
            TypeOfFuel = typeOfFuel;
            DateOnMarket = dateOnMarket;
            ModelClass = modelClass;
            Price = price;
            PassangerCapacity = passangerCapacity;
            IsAvalable = isAvalable;
        }
    }
}
