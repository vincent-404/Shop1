using Microsoft.AspNetCore.Mvc;
using Shop1.Data.Interfaces;
using Shop1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop1.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarscat)
        {
            _allCars = iAllCars;
            _allCategories = iCarscat;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Страница с автомобилями";
            CarsListViewModel obj = new CarsListViewModel();
            obj.allCars = _allCars.Cars;
            obj.currCategory = "Автомобили";

            return View(obj);

        }
    }
}
