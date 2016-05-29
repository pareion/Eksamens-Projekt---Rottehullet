using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RotteHulletMvvm.Misc
{
    class RelayCommand : ICommand
    {
        #region Fields
        private Action<object> viewExecute;
        private Predicate<object> viewCanExecute;
        private EventHandler canExecuteEvent;
        #endregion

        #region Delegate
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                canExecuteEvent += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                canExecuteEvent -= value;
            }
        }
        #endregion

        #region Constructors
        public RelayCommand(Action<object> execute) : this(execute, DefaultCanExecute) { }
        public RelayCommand(Action<object> execute, Predicate<object> predicts)
        {
            actionFilter(execute, predicts);
        }
        #endregion

        #region Methods
        public virtual bool CanExecute(object parameter)
        {
            return viewExecute != null && viewCanExecute(parameter);
        }

        public virtual void Execute(object parameter)
        {
            viewExecute(parameter);
        }

        public virtual void OnCanExecuteChanged(object parameter)
        {
            EventHandler handler = canExecuteEvent;
            if (handler != null)
            {
                handler.Invoke(parameter, EventArgs.Empty);
            }
        }

        private static bool DefaultCanExecute(object parameter)
        {
            return true;
        }

        protected void actionFilter(Action<object> action, Predicate<object> predicts)
        {
            if (action == null)
            {
                throw new ArgumentNullException("execute");
            }
            if (predicts == null)
            {
                throw new ArgumentNullException("predicts");
            }

            viewExecute = action;
            viewCanExecute = predicts;
        }
        #endregion
    }
}
