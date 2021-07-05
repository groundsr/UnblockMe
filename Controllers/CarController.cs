using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using UnblockMe.Data;
using UnblockMe.Models;

namespace UnblockMe.Controllers
{
    public class CarController : Controller
    {
        private readonly UnblockMeContext _context;

        public CarController(UnblockMeContext unblockMeContext)
        {
            _context = unblockMeContext;
        }

        public IActionResult Home(string searchString)
        {
            var cars = from c in _context.Car
                       select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(c => c.LicensePlate.ToLower().Contains(searchString));
            }

            return RedirectToAction("details");
        }
        public IActionResult Index(string searchString)
        {
            var cars = from c in _context.Car
                       select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(c => c.LicensePlate.ToLower().Contains(searchString));
            }
            return View(cars);
        }

        public IActionResult Details(string id)
        {
            var car = _context.Car.Include(car => car.Owner).Where(c => c.LicensePlate == id).FirstOrDefault();
            return View(car);
        }
    }
}
