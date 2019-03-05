namespace BlueOceanPhotos
{
    using System;
    using System.Windows.Input;

    public class DelegateCommand : ICommand
    {
        private Action _action;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
