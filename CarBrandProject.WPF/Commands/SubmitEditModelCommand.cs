using CarBrandProject.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Commands
{
    public class SubmitEditModelCommand : BaseCommand
    {
        private ModalNavigationStore _modalNavigationStore;

        public SubmitEditModelCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }

        public override async void Execute(object? parameter)
        {
            //TODO: Edit model to database

            _modalNavigationStore.Close();
        }
    }
}
