using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalValue { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
