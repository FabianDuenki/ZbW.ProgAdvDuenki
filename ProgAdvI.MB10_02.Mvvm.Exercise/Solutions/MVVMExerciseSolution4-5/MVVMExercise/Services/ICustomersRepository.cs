using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datasource;

namespace WpfExercise.Services {
    public interface ICustomersRepository {
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> UpdateCustomerAsync(Customer customer);
    }
}
