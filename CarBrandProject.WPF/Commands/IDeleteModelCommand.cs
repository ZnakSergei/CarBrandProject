using System;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Commands
{
    public interface IDeleteModelCommand
    {
        public Task Execute(Guid modelId);
    }
}
