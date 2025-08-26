using Microsoft.Data.SqlClient;
using System.Diagnostics.Metrics;

namespace OrderApp {
    internal class Program {
        static void Main(string[] args) {
            var sqlConnection = new SqlConnection("Server=.;Database=ShopDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            var processor = new OrderProcessor(new EmailNotifier(), new OrderRepository(sqlConnection));

            var items = new List<OrderItem> {
                    new() { Sku = "A", Qty = 2, Price = 120m },
                    new() { Sku = "B", Qty = 1, Price = 400m }
            };

            var order = new Order {
                CustomerEmail = "kunde@beispiel.ch",
                Phone = "+41790000000",
                Items = items
            };

            processor.Process(order);

            processor.Notifier = new SmsNotifier();
            processor.Process(order);
        }
    }
}