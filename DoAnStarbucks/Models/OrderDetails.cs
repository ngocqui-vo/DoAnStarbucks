using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnStarbucks.Models
{
    public class OrderDetails
    {
        public string OrderID { get; set; }
        public Order Order { get; set; }
        public string ProductID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalValue { get => Product.Price * Quantity; }
    }
}
