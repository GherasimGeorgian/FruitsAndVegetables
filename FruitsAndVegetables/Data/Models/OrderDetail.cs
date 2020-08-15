using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FruitsAndVegetables.Data.Models
{
    public class OrderDetail
    {

        [Key]
        public int OrederDetailId { get; set; }
        
        public int OrderId2 { get; set; }
        public int ProduceId { get; set; }

        public int Amount { get; set; }
        public decimal Price { get; set; }
        public virtual Product Product {get;set;}
        public virtual Order Order { get; set; }
    }
}
