using System;
using System.Windows.Input;

namespace WpfApp1
{
    public class ViewModel
    {
        public ViewModel()
        {
            Data = new Data();
            

            IncrementCommand = new RelayCommand(Increment);
            DecrementCommand = new DecrementCommand(Data);
        }

        public int Value { get; set; }
        public Data Data { get; set; }

        public ICommand IncrementCommand { get; set; }

        public ICommand DecrementCommand { get; set; }

        private void Increment()
        {
            Data.Value++;
        }
    }

    public class RelayCommand : ICommand
    {

        private Action _action;

        public RelayCommand(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public event EventHandler CanExecuteChanged;
    }
}