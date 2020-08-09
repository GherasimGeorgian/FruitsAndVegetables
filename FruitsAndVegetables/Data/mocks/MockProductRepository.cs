using FruitsAndVegetables.Data.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitsAndVegetables.Data.Models;
namespace FruitsAndVegetables.Data.mocks
{
    public class MockProductRepository:IProductRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();
        public Product GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Products
        {
            get
            {
                return new List<Product>
                {
                    new Product {
                        Name = "Banane",
                        Price = 7.95M, ShortDescription = "Banane premium calitatea ITara de origine: Ecuador",
                        LongDescription = "A se pastra la loc uscat si racoros, ferit de actiunea directa a soarelui.",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "https://api.time.com/wp-content/uploads/2019/11/gettyimages-459761948.jpg?w=800&quality=85",
                        InStock = true,
                        IsPreferredProduct = true,
                        ImageThumbnailUrl = "https://api.time.com/wp-content/uploads/2019/11/gettyimages-459761948.jpg?w=800&quality=85"
                    },
                    new Product {
                        Name = "Rosii",
                        Price = 12.95M, ShortDescription = "Rosii premium calitatea ITara de origine: Ecuador.",
                        LongDescription = "A se pastra la loc uscat si racoros, ferit de actiunea directa a soarelui.",
                        Category =  _categoryRepository.Categories.Last(),
                        ImageUrl = "https://api.time.com/wp-content/uploads/2019/11/gettyimages-459761948.jpg?w=800&quality=85",
                        InStock = true,
                        IsPreferredProduct = false,
                        ImageThumbnailUrl = "https://api.time.com/wp-content/uploads/2019/11/gettyimages-459761948.jpg?w=800&quality=85"
                    },
                    new Product {
                        Name = "Cartofi",
                        Price = 12.95M, ShortDescription = "Cartofi premium calitatea ITara de origine: Ecuador.",
                        LongDescription ="A se pastra la loc uscat si racoros, ferit de actiunea directa a soarelui.",
                        Category =  _categoryRepository.Categories.Last(),
                        ImageUrl = "https://api.time.com/wp-content/uploads/2019/11/gettyimages-459761948.jpg?w=800&quality=85",
                        InStock = true,
                        IsPreferredProduct = false,
                        ImageThumbnailUrl = "https://api.time.com/wp-content/uploads/2019/11/gettyimages-459761948.jpg?w=800&quality=85"
                    },
                    new Product
                    {
                        Name = "Piersici",
                        Price = 12.95M,
                        ShortDescription = "Piersici premium calitatea ITara de origine: Ecuador.",
                        LongDescription = "A se pastra la loc uscat si racoros, ferit de actiunea directa a soarelui.",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "https://api.time.com/wp-content/uploads/2019/11/gettyimages-459761948.jpg?w=800&quality=85",
                        InStock = true,
                        IsPreferredProduct = false,
                        ImageThumbnailUrl = "https://api.time.com/wp-content/uploads/2019/11/gettyimages-459761948.jpg?w=800&quality=85"
                    }
                };
            }
        }
        public IEnumerable<Product> PreferredProducts { get; }
        
    }
}
