using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UnblockMe.Models
{
    public partial class Car
    {
        public string LicensePlate { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public string BlockedLicensePlate { get; set; }
        public string BlockedByLicensePlate { get; set; }
        public string OwnerId { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }

        public virtual AspNetUsers Owner { get; set; }
    }
}
