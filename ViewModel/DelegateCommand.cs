using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chat_Application_Clients.ViewModel
{
    public class DelegateCommand<T> : System.Windows.Input.ICommand where T:class
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;
        private Action<T> execute;
        private object p;

        //public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<T> execute)
            : this(execute, null)
        {

        }

        public DelegateCommand(Action<T> execute,Predicate<T> canExecute)
           
        {
            _canExecute = canExecute;
            _execute = execute;
        }
    

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;

            return _canExecute((T)parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }
        }
        public void RaiseCanExecuteChange()
        {
            CommandManager.InvalidateRequerySuggested();
        }
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}
