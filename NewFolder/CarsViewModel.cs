using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnblockMe.Models;

namespace UnblockMe.NewFolder
{
    public class CarsViewModel
    {
        public IEnumerable<Car> FilteredByLocation;
        public IEnumerable<Car> FilteredBySearch;
        public IEnumerable<Car> AllCars;
    }
}
