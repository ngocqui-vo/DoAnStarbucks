using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnStarbucks.Models
{
    internal class Promotion
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string PromotionValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string ProductTypeID { get; set; }
        public ProductType ProductType { get; set; }
    }
}
