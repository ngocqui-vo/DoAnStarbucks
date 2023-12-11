using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnStarbucks.Models
{
    public class Branch
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OpeningHourID { get; set; }
        public OpeningHour OpeningHour { get; set; }
        public string ManagerID { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
