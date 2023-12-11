using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnStarbucks.Models
{
    public class Employee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }
        public string BrandID { get; set; }
        public Branch Branch { get; set; }
        public string PositionID { get; set; }
        public Position Position { get; set; }
    }
}
