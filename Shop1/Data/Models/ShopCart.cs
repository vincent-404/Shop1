﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop1.Data.Models
{
    public class ShopCart 
    {
        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public string ShopCartId { get; set; }

        public List<ShopCartItem> listShopItems { get; set; }
        
        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Car car)
        {
            appDBContent.ShopCartItem.Add(new ShopCartItem { 
                ShopCartId = ShopCartId,
                car = car,
                price = car.price
            });
            appDBContent.SaveChanges();
        }
                                    //g
        public List<ShopCartItem> GetShopItems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList();
        }

    }
}
