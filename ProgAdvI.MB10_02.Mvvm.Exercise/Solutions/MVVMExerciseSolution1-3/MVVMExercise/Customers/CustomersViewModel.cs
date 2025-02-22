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
            this.CurrentCustomer = this.Customers[0];
        }

        public ObservableCollection<Customer> Customers { get; set; }

        public Customer CurrentCustomer { get; set; }
    }
}
