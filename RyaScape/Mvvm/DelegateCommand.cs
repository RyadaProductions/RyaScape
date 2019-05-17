using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RyaScape.Mvvm
{
    public class DelegateCommand : DelegateCommand<object>
    {
        public DelegateCommand(Action pExecute) : base(vCommand => pExecute()) { }

        public DelegateCommand(Action pExecute, Func<bool> pCanExecute) : base(vCommand => pExecute(), vCommand => pCanExecute()) { }
    }

    public class DelegateCommand<T> : ICommand
    {
        private readonly Func<T, bool> fCanExecute;
        private readonly Action<T> fExecute;
        private bool fIsExecuting;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DelegateCommand(Action<T> pExecute) : this(pExecute, null) { }

        public DelegateCommand(Action<T> pExecute, Func<T, bool> pCanExecute)
        {
            fExecute = pExecute ?? throw new ArgumentException("pExecute", "Method to execute cannot be null");
            fCanExecute = pCanExecute;
        }

        bool ICommand.CanExecute(object pParameter)
        {
            return !fIsExecuting && CanExecute((T)pParameter);
        }

        void ICommand.Execute(object pParameter)
        {
            fIsExecuting = true;

            try
            {
                RaiseCanExecuteChanged();
                Execute((T)pParameter);
            }
            finally
            {
                fIsExecuting = false;
                RaiseCanExecuteChanged();
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        public bool CanExecute(T pParameter)
        {
            return (fCanExecute == null) ? true : fCanExecute(pParameter);
        }

        public void Execute(T pParameter)
        {
            fExecute(pParameter);
        }
    }
}
