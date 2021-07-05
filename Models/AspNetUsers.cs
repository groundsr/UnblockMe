using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UnblockMe.Models
{
    public partial class AspNetUsers : IdentityUser
    {
        public AspNetUsers()
        {
            Car = new HashSet<Car>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Rating { get; set; }
        public string Pictures { get; set; }

        public virtual ICollection<Car> Car { get; set; }
    }
}
