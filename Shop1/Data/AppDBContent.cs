using Microsoft.EntityFrameworkCore;
using Shop1.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Shop1.Data
{
    public class AppDBContent: DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }

        public Microsoft.EntityFrameworkCore.DbSet<Car> Car { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Category> Category { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<ShopCartItem> ShopCartItem { get; set; }


    }
}
