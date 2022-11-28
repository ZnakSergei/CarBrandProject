using CarBrandProject.WPF.Models;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Commands
{
    public interface ICreateBrandCommand
    {
        Task Execute(BrandModel brandModel);
    }
}
