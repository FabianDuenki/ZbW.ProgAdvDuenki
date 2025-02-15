using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp1.Properties;

namespace WpfApp1
{
    public class Data : INotifyPropertyChanged
    {
        private int _counter;
        public string Text => _counter.ToString();

        public int Value
        {
            get { return _counter; }
            set
            {
                _counter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Text));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}