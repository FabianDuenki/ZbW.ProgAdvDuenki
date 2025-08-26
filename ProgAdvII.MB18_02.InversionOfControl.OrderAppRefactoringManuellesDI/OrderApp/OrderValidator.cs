using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{
    public class OrderValidator
    {
        public OrderValidator() { }
        public void validate(Order order)
        {
            if (order == null || order.Items == null || order.Items.Count == 0)
                throw new Exception("Order invalid");
        }
    }
}
