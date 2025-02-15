using System;
using System.Windows.Input;

namespace WpfApp1
{
    public class DecrementCommand : ICommand
    {
        private Data _data;

        public DecrementCommand(Data data)
        {
            _data = data;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _data.Value--;
        }

        public event EventHandler CanExecuteChanged;
    }
}