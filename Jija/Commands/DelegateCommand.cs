using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace YandexTranslate.Commands
{
    class DelegateCommand : ICommand
    {
        #region Constructors

        /// <summary>
        ///     Constructor
        /// </summary>
        public DelegateCommand(Action executeMethod)
        {
            this._executeMethod = executeMethod;
        }
        public DelegateCommand(Action executeMethod, Func<bool> canExecute)
        {
            this._executeMethod = executeMethod;
            this._canExecuteMethod = canExecute;
        }

        /// <summary>
        ///     Constructor
        /// </summary>


        #endregion

        #region Public Methods

        /// <summary>
        ///     Method to determine if the command can be executed
        /// </summary>
        public bool CanExecute()
        {
            return _canExecuteMethod != null ? _canExecuteMethod() : true;
        }

        /// <summary>
        ///     Execution of the command
        /// </summary>
        public void Execute()
        {
            _executeMethod?.Invoke();
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (!_isAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested += value;
                }

            }
            remove
            {
                if (!_isAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested -= value;
                }

            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        void ICommand.Execute(object parameter)
        {
            Execute();
        }

        #endregion

        #region Data

        private readonly Action _executeMethod = null;
        private readonly Func<bool> _canExecuteMethod = null;
        private bool _isAutomaticRequeryDisabled = false;
        private List<WeakReference> _canExecuteChangedHandlers;
        private Func<bool> canExecuteMethod;
        private bool v;

        #endregion
    }
}
