using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{
    public class OrderRepository
    {
        private SqlConnection _sqlConnection;
        public OrderRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public void Add(Order order)
        {
            using (_sqlConnection)
            {
                _sqlConnection.Open();
                var cmd = _sqlConnection.CreateCommand();
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
        }
    }
}
