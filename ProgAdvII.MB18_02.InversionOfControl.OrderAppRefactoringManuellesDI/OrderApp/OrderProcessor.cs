
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace OrderApp {
    public class OrderProcessor {
        private readonly EmailNotifier _email = new EmailNotifier();
        private readonly SmsNotifier _sms = new SmsNotifier();

        private const string ConnString =
            "Server=.;Database=ShopDb;Trusted_Connection=True;MultipleActiveResultSets=true";

        public void Process(Order order, string notifyChannel) {
            if (order == null || order.Items == null || order.Items.Count == 0)
                throw new Exception("Order invalid");

            decimal subtotal = 0m;
            foreach (var it in order.Items) {
                if (it.Price < 0 || it.Qty <= 0)
                    throw new Exception("Item invalid");
                subtotal += it.Price * it.Qty;
            }

            var taxRate = 0.081m;      
            var discount = 0m;
            if (subtotal > 500) discount = 0.05m;
            if (subtotal > 1000) discount = 0.1m;  

            var total = (subtotal - (subtotal * discount)) * (1 + taxRate);

            order.OrderId = Guid.NewGuid().ToString();
            order.CreatedAt = DateTime.Now;
            order.Total = total;

            using (var con = new SqlConnection(ConnString)) {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText =
                    "INSERT INTO Orders(OrderId, CustomerEmail, Phone, Total, CreatedAt) " +
                    "VALUES(@id, @email, @phone, @total, @ts)";
                cmd.Parameters.AddWithValue("@id", order.OrderId);
                cmd.Parameters.AddWithValue("@email", order.CustomerEmail);
                cmd.Parameters.AddWithValue("@phone", order.Phone);
                cmd.Parameters.AddWithValue("@total", order.Total);
                cmd.Parameters.AddWithValue("@ts", order.CreatedAt);
                cmd.ExecuteNonQuery();
            }

            var fromEmail = ConfigurationManager.AppSettings["Mail:From"] ?? "noreply@example.com";
            var smsSender = ConfigurationManager.AppSettings["Sms:Sender"] ?? "SHOP";

            try {
                var msg = $"Bestellung {order.OrderId} erhalten, Total {order.Total:0.00} CHF";
                if (notifyChannel == "email")
                    _email.Send(fromEmail, order.CustomerEmail, "Bestellbestaetigung", msg);
                else if (notifyChannel == "sms")
                    _sms.Send(smsSender, order.Phone, msg);
                else
                    Console.WriteLine("Kein Versandkanal gewaehlt.");
            } catch (Exception ex) {
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
    public class EmailNotifier {
        public void Send(string from, string to, string subject, string body)
            => Console.WriteLine($"[EMAIL] {from} -> {to} | {subject} | {body}");
    }

    public class SmsNotifier {
        public void Send(string from, string to, string body)
            => Console.WriteLine($"[SMS] {from} -> {to} | {body}");
    }

}
