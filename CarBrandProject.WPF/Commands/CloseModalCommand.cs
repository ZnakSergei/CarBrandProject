using CarBrandProject.WPF.Stores;

namespace CarBrandProject.WPF.Commands
{
    public class CloseModalCommand : BaseCommand
    {
        private ModalNavigationStore _modalNavigationStore;
        public CloseModalCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }
        public override void Execute(object? parameter)
        {
            _modalNavigationStore.Close();
        }
    }
}
