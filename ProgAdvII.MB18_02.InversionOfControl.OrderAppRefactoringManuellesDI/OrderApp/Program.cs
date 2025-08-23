using System.Diagnostics.Metrics;

namespace OrderApp {
    internal class Program {
        static void Main(string[] args) {
            var processor = new OrderProcessor();

            var order = new Order {
                CustomerEmail = "kunde@beispiel.ch",
                Phone = "+41790000000",
                Items = new List<OrderItem> {
                    new() { Sku = "A", Qty = 2, Price = 120m },
                    new() { Sku = "B", Qty = 1, Price = 400m }
                }
            };

            processor.Process(order, "email");
            processor.Process(order, "sms");
        }
    }
}