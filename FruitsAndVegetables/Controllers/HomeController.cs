using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitsAndVegetables.Data.interfaces;
using FruitsAndVegetables.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FruitsAndVegetables.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PrefferedProducts = _productRepository.PreferredProducts
            };
        return View(homeViewModel);
        }
    }
    
}
