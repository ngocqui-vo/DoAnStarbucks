using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnStarbucks.Models
{
    public class Order
    {
        public string ID { get; set; }
        public string Status { get; set; }
        public DateTime OrderDateTime { get; set; }
        public decimal TotalValue { get; set; }
        public string CustomerID { get; set; }
        public Customer Customer { get; set; }
        public string EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public string PaymentMethodID { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
