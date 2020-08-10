using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitsAndVegetables.Data.Models;

namespace FruitsAndVegetables.Data
{
    public class DbInitializer
    {
        public static void Seed(IServiceProvider applicationBuilder)
        {
            AppDbContext context =
             applicationBuilder.GetRequiredService<AppDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }
            if (!context.Products.Any())
            {
                context.AddRange
                (
                    new Product
                    {
                        Name = "Banane",
                        Price = 7.95M,
                        ShortDescription = "Banane premium calitatea ITara de origine: Ecuador",
                        LongDescription = "A se pastra la loc uscat si racoros, ferit de actiunea directa a soarelui.",
                        Category = Categories["Fruit"],
                        ImageUrl = "https://api.time.com/wp-content/uploads/2019/11/gettyimages-459761948.jpg?w=800&quality=85",
                        InStock = true,
                        IsPreferredProduct = true,
                        ImageThumbnailUrl = "https://api.time.com/wp-content/uploads/2019/11/gettyimages-459761948.jpg?w=800&quality=85"
                    },
                    new Product
                    {
                        Name = "Rosii",
                        Price = 12.95M,
                        ShortDescription = "Rosii premium calitatea ITara de origine: Ecuador.",
                        LongDescription = "A se pastra la loc uscat si racoros, ferit de actiunea directa a soarelui.",
                        Category = Categories["Vegetables"],
                        ImageUrl = "https://api.time.com/wp-content/uploads/2019/11/gettyimages-459761948.jpg?w=800&quality=85",
                        InStock = true,
                        IsPreferredProduct = false,
                        ImageThumbnailUrl = "https://api.time.com/wp-content/uploads/2019/11/gettyimages-459761948.jpg?w=800&quality=85"
                    },
                    new Product
                    {
                        Name = "Cartofi",
                        Price = 12.95M,
                        ShortDescription = "Cartofi premium calitatea ITara de origine: Ecuador.",
                        LongDescription = "A se pastra la loc uscat si racoros, ferit de actiunea directa a soarelui.",
                        Category = Categories["Vegetables"],
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
                        Category = Categories["Fruit"],
                        ImageUrl = "https://api.time.com/wp-content/uploads/2019/11/gettyimages-459761948.jpg?w=800&quality=85",
                        InStock = true,
                        IsPreferredProduct = false,
                        ImageThumbnailUrl = "https://api.time.com/wp-content/uploads/2019/11/gettyimages-459761948.jpg?w=800&quality=85"
                    }
                );
            }

            context.SaveChanges();
        }
        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Fruit", Description="All fruits" },
                        new Category { CategoryName = "Vegetables", Description="All vegetables" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
    }
}
