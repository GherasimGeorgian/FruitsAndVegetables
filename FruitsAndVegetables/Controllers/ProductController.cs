using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitsAndVegetables.Data.interfaces;
using FruitsAndVegetables.ViewModels;
using Microsoft.AspNetCore.Mvc; //
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
        public ViewResult List()
        {
           
            ViewBag.Name = "List Products";
            ProductListViewModel vm = new ProductListViewModel();
            vm.Products = _productRepository.Products;
            vm.CurrentCategory = "FruitsAndVegetablesCategory";
            return View(vm);
        }
    }
}
