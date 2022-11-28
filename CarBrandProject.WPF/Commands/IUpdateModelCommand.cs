using CarBrandProject.WPF.Models;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Commands
{
    public interface IUpdateModelCommand
    {
        public Task Execute(ModelsModel modelsModel);
    }
}
