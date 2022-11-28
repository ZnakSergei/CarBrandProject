using System;
using System.Windows.Input;

namespace CarBrandProject.WPF.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter)
        {
            return true;
        }
        public abstract void Execute(object? parameter);
        protected virtual void OnCanExecuteChange()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
        
    }
}