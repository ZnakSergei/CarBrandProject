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
        private ModelsModel _modelsModel;
        public Guid ModelId { get; }
       
        private ModalNavigationStore modalNavigationStore;

        public ModelDetailsFormViewModel ModelDetailsFormViewModel { get; set; }
        public EditModelDetailsViewModel(ModelsModel modelsModel, ModelsStore modelsStore, ModalNavigationStore modalNavigationStore)
        {
            ModelId = modelsModel.ModelId;

            ICommand submitModelCommand = new SubmitEditModelCommand(this, modelsStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);

            ModelDetailsFormViewModel = new ModelDetailsFormViewModel(submitModelCommand, cancelCommand)
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
