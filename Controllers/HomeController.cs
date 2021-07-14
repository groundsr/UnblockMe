using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UnblockMe.Data;
using UnblockMe.Models;
using UnblockMe.NewFolder;
using UnblockMe.Services;

namespace UnblockMe.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UnblockMeContext _context;
        private readonly ICarService _carService;

        private readonly UserManager<AspNetUsers> _userManager;

        public HomeController(ILogger<HomeController> logger, UnblockMeContext context, UserManager<AspNetUsers> userManager,ICarService carService)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _carService = carService;
        }

        public IActionResult Index(string searchString)
        {
            var carsViewModel = new CarsViewModel();
            var userId = _userManager.GetUserId(HttpContext.User);
            var myCar = _context.Car.Where(c => c.OwnerId == userId).FirstOrDefault();
            var cars = _context.Car.Where(c => c.OwnerId != userId).AsEnumerable();
            var filteredCars = cars.Where(c => _carService.CalculateDistance(myCar, c) <= 1).AsEnumerable();


            carsViewModel.AllCars = cars;
            carsViewModel.FilteredByLocation = filteredCars;

            if (!string.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(c => c.LicensePlate.ToLower().Contains(searchString));
            }
            carsViewModel.FilteredBySearch = cars;
            return View(carsViewModel);
        }

        //public IActionResult BlockUnblockButtons()
        //{
        //    var userId = _userManager.GetUserId(HttpContext.User);
        //    var myCar = _context.Car.Where(c => c.OwnerId == userId).FirstOrDefault();
        //    var cars = _context.Car.Where(c => c.OwnerId != userId).AsEnumerable();

        //    return View(filteredCars);
        //}



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
