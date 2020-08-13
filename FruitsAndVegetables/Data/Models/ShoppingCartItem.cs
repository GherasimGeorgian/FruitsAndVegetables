using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitsAndVegetables.Data.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }

        public Product Product { get; set; }

        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }

        public  ShoppingCartItem()
        {
            Product = new Product
                    {
                        Name = "Banane",
                        Price = 7.95M,
                        ShortDescription = "Banane premium calitatea ITara de origine: Ecuador",
                        LongDescription = "A se pastra la loc uscat si racoros, ferit de actiunea directa a soarelui.",
                      //  Category = product.Category,
                        ImageUrl = "https://api.time.com/wp-content/uploads/2019/11/gettyimages-459761948.jpg?w=800&quality=85",
                        InStock = true,
                        IsPreferredProduct = true,
                        ImageThumbnailUrl = "https://api.time.com/wp-content/uploads/2019/11/gettyimages-459761948.jpg?w=800&quality=85",
                        CategoryId = 1
                    };
        }
        
    }
}
