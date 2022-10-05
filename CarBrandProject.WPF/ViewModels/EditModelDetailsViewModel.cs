using CarBrandProject.WPF.Commands;
using CarBrandProject.WPF.Models;
using CarBrandProject.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarBrandProject.WPF.ViewModels
{
    public class EditModelDetailsViewModel : BaseViewModel
    {
        public ModelDetailsFormViewModel ModelDetailsFormViewModel { get; set; }
        public EditModelDetailsViewModel(ModelsModel modelsModel, ModalNavigationStore modalNavigationStore)
        {
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);

            ModelDetailsFormViewModel = new ModelDetailsFormViewModel(null, cancelCommand)
            {
                ModelName = modelsModel.ModelName,
                TypeOfFuel = modelsModel.TypeOfFuel,
                DateOnMarket = modelsModel.DateOnMarket,
                ModelClass = modelsModel.ModelClass,
                Price = modelsModel.Price,
                PassangerCapacity = modelsModel.PassangerCapacity,
                IsAvalable = modelsModel.IsAvalable
            };
        }
    }
}
