using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnStarbucks.Models
{
    public class Promotion
    {
        public string ID { get; set; }
        public string Code { get; set; }
        public float PromotionValue { get; set; }
        public int UseNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string ProductID { get; set; }
        public Product Product { get; set; }
        public bool IsValid 
        { 
            get 
            {
                bool a = UseNumber > 0;
                bool b = (DateTime.Now >=  StartDate && DateTime.Now <= EndDate);
                return  a&&b ;
            }
        }
    }
}
