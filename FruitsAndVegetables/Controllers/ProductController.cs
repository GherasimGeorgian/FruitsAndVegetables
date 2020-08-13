using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitsAndVegetables.Data.interfaces;
using FruitsAndVegetables.ViewModels;
using Microsoft.AspNetCore.Mvc; //
using FruitsAndVegetables.Data.Models;

namespace FruitsAndVegetables.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Product> products;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                products = _productRepository.Products.OrderBy(p => p.ProductId);
                currentCategory = "All products";
            }
            else
            {
                if (string.Equals("Fruit", _category, StringComparison.OrdinalIgnoreCase))
                    products = _productRepository.Products.Where(p => p.Category.CategoryName.Equals("Fruit")).OrderBy(p => p.Name);
                else
                    products = _productRepository.Products.Where(p => p.Category.CategoryName.Equals("Vegetable")).OrderBy(p => p.Name);

                currentCategory = _category;
            }

            return View(new ProductsListViewModel
            {
                Products = products,
                CurrentCategory = currentCategory
            });
        }

        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Product> products;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                products = _productRepository.Products.OrderBy(p => p.ProductId);
            }
            else
            {
                products = _productRepository.Products.Where(p => p.Name.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Product/List.cshtml", new ProductsListViewModel { Products = products, CurrentCategory = "All products" });
        }

        public ViewResult Details(int productId)
        {
            var product = _productRepository.Products.FirstOrDefault(d => d.ProductId == productId);
            if (product == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(product);
        }
    }
}
