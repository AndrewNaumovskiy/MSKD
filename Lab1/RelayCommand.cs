using System;
using System.Windows.Input;

namespace Lab1
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value; 
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand (Action<object> execute, Func<object,bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object param)
        {
            return _canExecute == null || _canExecute(param);
        }

        public void Execute(object param)
        {
            _execute(param);
        }
    }
}
