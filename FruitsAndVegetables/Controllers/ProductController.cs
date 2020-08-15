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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        public ProductController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }
        // public ViewResult List()
        // {

        //     ViewBag.Name = "List Products";
        //     ProductListViewModel vm = new ProductListViewModel();
        //     vm.Products = _productRepository.Products;
        //    vm.CurrentCategory = "FruitsAndVegetablesCategory";
        //    return View(vm);
        //}

        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Product> products;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                products = _productRepository.Products.OrderBy(p => p.ProduceId);
                currentCategory = "All Products";
            }
            else
            {
                if (string.Equals("Fruit", _category, StringComparison.OrdinalIgnoreCase))
                   products = _productRepository.Products.Where(p => p.CategoryId.Equals(1)).OrderBy(p => p.Name);
                else
                    products = _productRepository.Products.Where(p => p.CategoryId.Equals(2)).OrderBy(p => p.Name);

                currentCategory = _category;
            }

            return View(new ProductListViewModel
            {
                Products = products,
                CurrentCategory = currentCategory
            });
        }

        
    }
}
