using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UnblockMe.Models
{
    public partial class Location
    {
        public Guid Id { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
    }
}
