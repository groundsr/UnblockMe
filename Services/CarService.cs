using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using UnblockMe.Data;
using UnblockMe.Models;
using Nexmo.Api;

namespace UnblockMe.Services
{
    public class CarService : ICarService
    {

        private readonly UnblockMeContext _context;
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CarService(UnblockMeContext context, UserManager<AspNetUsers> userManager
            , IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public void Create(Car car)
        {
            var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            car.OwnerId = userId;
            _context.Car.Add(car);
            _context.SaveChanges();

        }

        public Car GetDetails(string id)
        {
            var car = _context.Car.Include(car => car.Owner).Where(c => c.LicensePlate == id).FirstOrDefault();
            return car;
        }

        public void SendSMS(string to, string message)
        {
            var results = SMS.Send(new SMS.SMSRequest
            {
                from = Configuration.Instance.Settings["appsettings:NEXMO_FROM_NUMBER"],
                to = to,
                text = message
            });
        }

        public IEnumerable<Car> GetAll()
        {
            var cars = _context.Car.AsEnumerable();
            return cars;
        }

        public void Update(Car car)
        {
            var carToUpdate = _context.Car.Find(car.LicensePlate);

            if (carToUpdate != null)
            {
                carToUpdate.Maker = car.Maker;
                carToUpdate.Model = car.Model;
                carToUpdate.Colour = car.Colour;
                _context.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            var car = _context.Car.Find(id);
            _context.Car.Remove(car);
            _context.SaveChanges();
        }

        public void UpdateLocation(double lat, double lng)
        {
            var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            var car = _context.Car.Where(u => u.OwnerId == userId).AsEnumerable();

            foreach(var c in car)
            {
                c.lat = lat;
                c.lng = lng;
            }
            _context.SaveChanges();
        }

        public double CalculateDistance(Car car1, Car car2)
        {
            double rlat1 = Math.PI * car1.lat / 180;
            double rlat2 = Math.PI * car2.lat / 180;
            double theta = car1.lng - car2.lng;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return dist;
        }
    }
}
