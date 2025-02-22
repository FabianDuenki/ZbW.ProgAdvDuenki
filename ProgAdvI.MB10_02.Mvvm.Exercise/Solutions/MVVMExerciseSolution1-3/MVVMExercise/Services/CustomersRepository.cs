using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datasource;

namespace WpfExercise.Services {
    public class CustomersRepository : ICustomersRepository {
        public Task<List<Customer>> GetCustomersAsync() {
            return Task.Factory.StartNew(() => Data.Load().Customers.CustomerList.ToList()) ;
        }

        public Task<Customer> UpdateCustomerAsync(Customer customer) {
            return Task.Factory.StartNew(() => {
                var data = Data.Load();
                var list = data.Customers.CustomerList;
                var index = list.IndexOf(customer);
                if (index >= 0) {
                    list[index] = customer;
                } else {
                    list.Add(customer);
                }

                data.Save();
                return customer;
            });
        }
    }
}
