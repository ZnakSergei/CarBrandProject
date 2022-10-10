using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Commands
{
    public abstract class AsyncBaseCommand : BaseCommand
    {
        public override async void Execute(object? parameter)
        {
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception) { }          
        }
        public abstract Task ExecuteAsync(object parameter);
       
    }
}
