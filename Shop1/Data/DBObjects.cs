using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop1.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        { //static
            
            
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Car.Any())
            {
                content.AddRange(
                    new Car
                    {
                        name = "Tesla Model S",
                        shortDesc = "Быстрый автомобиль",
                        longDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
                        img = "/img/tesla.jpg",
                        price = 45000,
                        isFavorite = true,
                        available = true,
                        Category = Categories["Электромобили"]
                    },
                    new Car
                    {
                        name = "Ford Fiesta",
                        shortDesc = "Тихий и спокойный",
                        longDesc = "Комфортный автомобиль для городской жизни",
                        img = "/img/fiesta.jpg",
                        price = 11000,
                        isFavorite = false,
                        available = true,
                        Category = Categories["Бензиновые автомобили"]
                    },
                    new Car
                    {
                        name = "BMW M3",
                        shortDesc = "Дерзкий и стильный",
                        longDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/m3.jpg",
                        price = 65000,
                        isFavorite = true,
                        available = true,
                        Category = Categories["Бензиновые автомобили"]
                    },
                    new Car
                    {
                        name = "Mercedes C class",
                        shortDesc = "Уютный и большой",
                        longDesc = "Комфортный автомобиль для городской жизни",
                        img = "/img/mercedes.jpg",
                        price = 40000,
                        isFavorite = false,
                        available = false,
                        Category = Categories["Бензиновые автомобили"]
                    },
                    new Car
                    {
                        name = "Nissan Leaf",
                        shortDesc = "Безшумный и экономный",
                        longDesc = "Комфортный автомобиль для городской жизни",
                        img = "/img/nissan.jpg",
                        price = 14000,
                        isFavorite = true,
                        available = true,
                        Category = Categories["Электромобили"]
                    },
                    new Car
                    {
                        name = "Mitsubisi Pajero Sport 2021",
                        shortDesc = "Уютный и большой",
                        longDesc = "Комфортный автомобиль для по бездорожью",
                        img = "/img/pajero.jpeg",
                        price = 30000,
                        isFavorite = true,
                        available = true,
                        Category = Categories["Дизельные автомобили"]
                    }
                );
            };


            content.SaveChanges();

        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category { categoryName = "Электромобили", desc = "Современный вид транспорта"},
                        new Category { categoryName = "Бензиновые автомобили", desc = "Машины с двигателем внутреннего сгорания"},
                        new Category { categoryName = "Дизельные автомобили", desc = "Машины с двигателем внутреннего сгорания"},
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);
                }
                return category;
            }
        }

        
    }
}
