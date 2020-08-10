using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitsAndVegetables.Data.interfaces;
using FruitsAndVegetables.ViewModels;
using Microsoft.AspNetCore.Mvc; //
using Microsoft.AspNetCore.Hosting;

namespace FruitsAndVegetables.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private IWebHostEnvironment _env;

        public ProductController(ICategoryRepository categoryRepository, IProductRepository productRepository, IWebHostEnvironment env)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _env = env;
        }
        public ViewResult List()
        {
            string contentRootPath = _env.ContentRootPath;
            ViewBag.Name = "List Products";
            ProductListViewModel vm = new ProductListViewModel();
            vm.Products = _productRepository.Products;
            vm.CurrentCategory = "FruitsAndVegetablesCategory";
            return View(vm);
        }
    }
}
