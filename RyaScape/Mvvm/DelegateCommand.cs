using System;
using System.Windows.Input;

namespace RyaScape.Mvvm
{
    public class DelegateCommand : DelegateCommand<object>
    {
        public DelegateCommand(Action execute) : base(command => execute()) { }

        public DelegateCommand(Action execute, Func<bool> canExecute) : base(command => execute(), command => canExecute()) { }
    }

    public class DelegateCommand<T> : ICommand
    {
        private readonly Func<T, bool> _canExecute;
        private readonly Action<T> _execute;
        private bool _isExecuting;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public DelegateCommand(Action<T> execute) : this(execute, null) { }

        public DelegateCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentException("execute", "Method to execute cannot be null");
            _canExecute = canExecute;
        }

        bool ICommand.CanExecute(object parameter)
        {
            return !_isExecuting && CanExecute((T)parameter);
        }

        void ICommand.Execute(object parameter)
        {
            _isExecuting = true;

            try
            {
                RaiseCanExecuteChanged();
                Execute((T)parameter);
            }
            finally
            {
                _isExecuting = false;
                RaiseCanExecuteChanged();
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        public bool CanExecute(T parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(T parameter)
        {
            _execute(parameter);
        }
    }
}
