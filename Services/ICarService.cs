using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnblockMe.Models;

namespace UnblockMe.Services
{
    public interface ICarService
    {
        void Create(Car car);
        Car GetDetails(string id);
        void SendSMS(string to, string message);
        IEnumerable<Car> GetAll();
        void Update(Car car);
        void Delete(string id);
        void UpdateLocation(double lat, double lng);
        double CalculateDistance(Car car1, Car car2);
    }
}
