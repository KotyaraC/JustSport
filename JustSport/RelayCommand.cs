using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JustSport
{
    public class RelayCommand : ICommand
    {
        Action<object?> _execute;
        Func<object?, bool> _executeFunc;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object?> execute, Func<object?, bool>? executeFunc = null)
        {
            _execute = execute;
            _executeFunc = executeFunc;
        }

        public bool CanExecute(object? obj)
        {
            return _executeFunc == null || _executeFunc(obj);
        }
        public void Execute(object? obj)
        {
            _execute(obj);
        }
    }
    
}