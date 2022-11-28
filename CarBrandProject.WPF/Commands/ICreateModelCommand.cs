using CarBrandProject.WPF.Models;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Commands
{
    public interface ICreateModelCommand
    {
        Task Execute(ModelsModel modelsModel);
    }
}
