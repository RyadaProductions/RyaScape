using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RyaScape.Mvvm
{
    public class AwaitableDelegateCommand : AwaitableDelegateCommand<object>
    {
        public AwaitableDelegateCommand(Func<Task> execute) : base(command => execute()) { }

        public AwaitableDelegateCommand(Func<Task> execute, Func<bool> canExecute) : base(command => execute(), vCommand => canExecute()) { }
    }

    public class AwaitableDelegateCommand<T> : ICommand
    {
        private readonly Func<T, Task> _execute;
        private readonly DelegateCommand<T> _delegateCommand;
        private bool _isExecuting;

        public ICommand Command => this;

        public event EventHandler CanExecuteChanged
        {
            add => _delegateCommand.CanExecuteChanged += value;
            remove => _delegateCommand.CanExecuteChanged -= value;
        }

        public AwaitableDelegateCommand(Func<T, Task> execute) : this(execute, canExecute => true) { }

        public AwaitableDelegateCommand(Func<T, Task> execute, Func<T, bool> canExecute)
        {
            _execute = execute;
            _delegateCommand = new DelegateCommand<T>(executeDummy => { }, canExecute);
        }

        public void RaiseCanExecuteChanged()
        {
            _delegateCommand.RaiseCanExecuteChanged();
        }

        public bool CanExecute(object parameter)
        {
            return !_isExecuting && _delegateCommand.CanExecute((T)parameter);
        }

        public async void Execute(object parameter)
        {
            await ExecuteAsync((T)parameter);
        }

        public async Task ExecuteAsync(T @object)
        {
            try
            {
                _isExecuting = true;
                RaiseCanExecuteChanged();
                await _execute(@object);
            }
            finally
            {
                _isExecuting = false;
                RaiseCanExecuteChanged();
            }
        }
    }
}
