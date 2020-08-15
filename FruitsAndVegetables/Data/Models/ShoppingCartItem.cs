using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitsAndVegetables.Data.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public int ProduceId { get; set; }

        public int Amount { get; set; }

        public string NameProduct { get; set; }

        public decimal PriceProduct { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
