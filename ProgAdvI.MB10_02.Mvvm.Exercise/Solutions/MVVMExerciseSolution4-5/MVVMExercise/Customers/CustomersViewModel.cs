using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datasource;
using WpfExercise.Services;

namespace WpfExercise.Customers {
    public class CustomersViewModel {
        private readonly ICustomersRepository repository = new CustomersRepository();

        public CustomersViewModel() {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject())) {
                return;
            }

            this.Customers = new ObservableCollection<Customer>(repository.GetCustomersAsync().Result);
            this.SaveCommand = new RelayCommand(OnSave, CanSave);

        }

        private void OnSave() {
            this.repository.UpdateCustomerAsync(this.CurrentCustomer);
        }

        private bool CanSave() {
            return CurrentCustomer != null;
        }

        public ObservableCollection<Customer> Customers { get; set; }

        private Customer currentCustomer;

        public Customer CurrentCustomer {
            get => this.currentCustomer;
            set {
                this.currentCustomer = value;
                this.SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand SaveCommand { get; private set; }

    }
}
