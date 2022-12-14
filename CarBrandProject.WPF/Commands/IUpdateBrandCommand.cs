using CarBrandProject.WPF.Models;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Commands
{
    public interface IUpdateBrandCommand
    {
        Task Execute(BrandModel brandModel);
    }
}
