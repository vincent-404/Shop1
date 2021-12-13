﻿using Shop1.Data.Interfaces;
using Shop1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop1.Data.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { categoryName = "Электромобили", desc = "Современный вид транспорта", id = 1},
                    new Category { categoryName = "Бензиновые автомобили", desc = "Машины с двигателем внутреннего сгорания", id = 2},
                    new Category { categoryName = "Дизельные автомобили", desc = "Машины с двигателем внутреннего сгорания", id = 3},

                }; 
            }
        }
    }
}
