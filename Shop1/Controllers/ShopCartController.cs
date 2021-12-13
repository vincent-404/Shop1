using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Shop1.Data.Models;
using Shop1.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop1.ViewModels;
using Shop1.Data.Interfaces;

namespace Shop1.Controllers
{
    public class ShopCartController : Controller
    {
        
        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;
        public ShopCartController(IAllCars carRep, ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }
        public ViewResult Index()
        {
            var Items = _shopCart.GetShopItems();
            _shopCart.listShopItems = Items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };
            return View(obj);
        }
                                        //a
        public RedirectToActionResult AddToCart(int id)
        {
            var item = _carRep.Cars.FirstOrDefault(i => i.id == id);
            if(item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("index");
        }

    }
}
