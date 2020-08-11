﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitsAndVegetables.Data.interfaces;
using FruitsAndVegetables.Data.Models;
using FruitsAndVegetables.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FruitsAndVegetables.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartController(IProductRepository productRepository, ShoppingCart shoppingCart)
        {
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(sCVM);
        }

        public RedirectToActionResult AddToShoppingCart(int productId)
        {
            var selectedProduct = _productRepository.Products.FirstOrDefault(p => p.ProduceId == productId);
            if(selectedProduct!= null){
                _shoppingCart.AddToCart(selectedProduct,1);
            }
            return RedirectToAction("Index" );
        }
        public RedirectToActionResult RemoveFromShoppingCart(int productId)
        {
            var selectedProduct = _productRepository.Products.FirstOrDefault(p => p.ProduceId == productId);
            if (selectedProduct != null)
            {
                _shoppingCart.RemoveFromCart(selectedProduct);
            }
            return RedirectToAction("Index");
        }
    }
}
