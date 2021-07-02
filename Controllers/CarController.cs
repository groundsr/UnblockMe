using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public IActionResult Index()
        {
            List<Car> cars = _context.Car.ToList();
            return View(cars);
        }
    }
}
