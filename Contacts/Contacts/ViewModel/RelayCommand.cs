using System;
using System.Windows.Input;

namespace ContactsApp.ViewModel
{
    /// <summary>
    /// Описывает команду, реализуя интерфейс ICommand.
    /// </summary>
    internal class RelayCommand : ICommand
    {
        /// <summary>
        /// Создаёт экземпляр класса <see cref="RelayCommand"/>.
        /// </summary>
        /// <param name="execute">Описание логики команды.</param>
        public RelayCommand(Action<object> execute)
        {
            this._execute = execute;
        }

        /// <summary>
        /// Описание логики команды.
        /// </summary>
        private Action<object> _execute;

        /// <summary>
        /// Вызывается при изменении условий, указывающих, может ли команда выполняться.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Определяет, может ли команда выполняться.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        /// <returns>True.</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Выполняет логику команды.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        public void Execute(object parameter)
        {
            this._execute(parameter);
        }
    }
}

