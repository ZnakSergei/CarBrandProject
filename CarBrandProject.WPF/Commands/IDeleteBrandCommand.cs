using System;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Commands
{
    public interface IDeleteBrandCommand
    {
        Task Execute(Guid BrandId);
    }
}
