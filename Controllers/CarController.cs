using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using UnblockMe.Data;
using UnblockMe.Models;
using Nexmo.Api;
using UnblockMe.Services;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace UnblockMe.Controllers
{
    //[Authorize(Roles = "Admin")]
    //[Authorize(Roles = "User")]
    //[Authorize(Policy ="RequireAdministratorRole")]
    [Authorize]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly UnblockMeContext _context;
        private readonly UserManager<AspNetUsers> _userManager;

        public CarController(UnblockMeContext unblockMeContext, UserManager<AspNetUsers> userManager,
            ICarService carService)
        {
            _context = unblockMeContext;
            _userManager = userManager;
            _carService = carService;
        }
        public ActionResult Send(string phoneNumber)
        {
            phoneNumber = phoneNumber.Trim();
            ViewBag.PhoneNumber = phoneNumber;
            
            return View();
        }
        [HttpPost]
        public ActionResult Send(string to, string text)
        {
            _carService.SendSMS(to, text);
            return View();
        }


        public IActionResult Index(string searchstring)
        {

            var userid = _userManager.GetUserId(HttpContext.User);
            var cars = _context.Car.Where(c => c.OwnerId == userid);

            if (!string.IsNullOrEmpty(searchstring))
            {
                cars = cars.Where(c => c.LicensePlate.ToLower().Contains(searchstring));
            }
            return View(cars);
        }

        

        public IActionResult Details(string id)
        {
            var car = _carService.GetDetails(id);
            return View(car);
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                _carService.Create(car);
                return RedirectToAction("Index");

            }
            return View(car);
        }

        public IActionResult UpdateLocation(double lat, double lng)
        {
            _carService.UpdateLocation(lat, lng);
            return Ok();
        }

        [HttpPost]
        public IActionResult Update(Car car)
        {
            _carService.Update(car);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(string licensePlate)
        {
            _carService.Delete(licensePlate);
            return RedirectToAction("Index");
        }
        
        
    }
}
