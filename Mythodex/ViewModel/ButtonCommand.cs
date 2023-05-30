using System;
using System.Windows.Input;

namespace Mythodex.ViewModel
{
    internal class ButtonCommand : ICommand
    {
        private readonly Action<object> _execute;

        public ButtonCommand(Action<object> execute)
        {
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
