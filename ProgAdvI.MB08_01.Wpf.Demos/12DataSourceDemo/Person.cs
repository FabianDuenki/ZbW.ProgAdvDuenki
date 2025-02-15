using System.ComponentModel;

namespace BindingExample {
    public class Person : INotifyPropertyChanged {
        public string Name { get; set; }

        private double ageValue;

        public double Age {
            get => ageValue;
            set {
                if (value != ageValue) {
                    ageValue = value;
                    OnPropertyChanged("Age");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName) {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
