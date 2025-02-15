using System;
using System.Windows.Input;

namespace WpfApp1
{
    public class IncrementCommand : ICommand
    {
        private Data _data;

        public IncrementCommand(Data data)
        {
            _data = data;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _data.Value++;
        }

        public event EventHandler CanExecuteChanged;
    }
}