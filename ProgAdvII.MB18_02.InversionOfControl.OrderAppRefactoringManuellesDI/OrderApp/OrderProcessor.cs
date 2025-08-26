
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data.Common;

namespace OrderApp {
    public class OrderProcessor {
        private INotifier _notifier;
        private OrderRepository _orderRepository;

        public OrderProcessor(INotifier notifier, OrderRepository orderRepository)
        {
            this.Notifier = notifier;
            this._orderRepository = orderRepository;
        }

        public INotifier Notifier
        {
            get { return _notifier; }
            set { _notifier = value; }
        }

        public void Process(Order order) {
            OrderValidator orderValidator = new OrderValidator();
            orderValidator.validate(order);

            decimal subtotal = 0m;
            foreach (var item in order.Items) {
                if (item.Price < 0 || item.Qty <= 0)
                    throw new Exception("Item invalid");
                subtotal += item.Price * item.Qty;
            }

            var taxRate = 0.081m;      
            var discount = 0m;
            if (subtotal > 500) discount = 0.05m;
            if (subtotal > 1000) discount = 0.1m;  

            var total = (subtotal - (subtotal * discount)) * (1 + taxRate);

            order.OrderId = Guid.NewGuid().ToString();
            order.CreatedAt = DateTime.Now;
            order.Total = total;

            _orderRepository.Add(order);

            try
            {
                var msg = $"Bestellung {order.OrderId} erhalten, Total {order.Total:0.00} CHF";
                this._notifier.Send(order, msg);
            } 
            catch (Exception ex) 
            {
                Console.WriteLine("Fehler beim Benachrichtigen: " + ex.Message);
            }
        }
    }

    // Simple Modelle – mit Absicht minimal
    public class Order {
        public string OrderId { get; set; }
        public string CustomerEmail { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Total { get; set; }
        public List<OrderItem> Items { get; set; } = new();
    }

    public class OrderItem { public string Sku; public int Qty; public decimal Price; }

    // Dummy Notifier
    public class EmailNotifier : INotifier
    {
        public void Send(Order order, string message)
        {
            var from = ConfigurationManager.AppSettings["Mail:From"] ?? "noreply@example.com";
            var to = order.CustomerEmail;
            var subject = "Bestellbestätigung";
            Console.WriteLine($"[EMAIL] {from} -> {to} | {subject} | {message}");
        }
    }

    public class SmsNotifier : INotifier {
        public void Send(Order order, string message)
        {
            var from = ConfigurationManager.AppSettings["Sms:Sender"] ?? "SHOP";
            var to = order.Phone;
            Console.WriteLine($"[SMS] {from} -> {to} | {message}");
        }
    }

    public interface INotifier
    {
        public void Send(Order order, string message);
    }
}
