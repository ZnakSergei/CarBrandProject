using CarBrandProject.WPF.Commands;
using CarBrandProject.WPF.EntityFramework;
using CarBrandProject.WPF.EntityFramework.Commands;
using CarBrandProject.WPF.EntityFramework.Queries;
using CarBrandProject.WPF.Queries;
using CarBrandProject.WPF.Stores;
using CarBrandProject.WPF.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace CarBrandProject.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly BrandsDbContextFactory _brandsDbContextFactory;
        private readonly IGetAllBrandsQuery _getAllBrandsQuary;
        private readonly ICreateBrandCommand _createBrandCommand;
        private readonly IUpdateBrandCommand _updateBrandCommand;
        private readonly IDeleteBrandCommand _deleteBrandCommand;

        private readonly IGetAllModelsQuary _getAllModelsQuary;
        private readonly ICreateModelCommand _createModelCommand;
        private readonly IUpdateModelCommand _updateModelCommand;
        private readonly IDeleteModelCommand _deleteModelCommand;
        
        private readonly SelectedBrandStores _selectedBrandStores;
        private readonly SelectedModelStores _selectedModelStores;

        private readonly BrandsStores _brandsStores;
        private readonly ModelsStore _modelsStore;

        public App()
        {
            string connectionString = "Data Source=Brands.db";

            _brandsDbContextFactory = new BrandsDbContextFactory(
                new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
            _getAllBrandsQuary = new GetAllBrandsQuery(_brandsDbContextFactory);
            _createBrandCommand = new CreateBrandCommand(_brandsDbContextFactory);
            _updateBrandCommand = new UpdateBrandCommand(_brandsDbContextFactory);
            _deleteBrandCommand = new DeleteBrandCommand(_brandsDbContextFactory);
            _createModelCommand = new CreateModelCommand(_brandsDbContextFactory);
            _brandsStores = new BrandsStores(_getAllBrandsQuary, _createBrandCommand, _updateBrandCommand, _deleteBrandCommand);
            _modelsStore = new ModelsStore(_getAllModelsQuary, _createModelCommand, _updateModelCommand, _deleteModelCommand);
            _selectedBrandStores = new SelectedBrandStores(_brandsStores);
            _selectedModelStores = new SelectedModelStores(_modelsStore);

            _modalNavigationStore = new ModalNavigationStore();     
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            using (BrandsDbContext context = _brandsDbContextFactory.Create())
            {
                context.Database.Migrate();
            }

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore, 
                new CarBrandProjectViewModel(_brandsStores,
                _selectedBrandStores,
                _modelsStore, 
                _selectedModelStores, 
                _modalNavigationStore))
            };

            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
