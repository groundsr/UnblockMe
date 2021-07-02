using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UnblockMe.Models
{
    public partial class User
    {
        public User()
        {
            Car = new HashSet<Car>();
        }

        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("first_name")]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Column("last_name")]
        [StringLength(20)]
        public string LastName { get; set; }
        [Column("tel_number")]
        [StringLength(20)]
        public string TelNumber { get; set; }
        [Column("rating")]
        [StringLength(20)]
        public string Rating { get; set; }
        [Required]
        [Column("password")]
        [StringLength(20)]
        public string Password { get; set; }
        [Column("pictures")]
        [StringLength(50)]
        public string Pictures { get; set; }

        [InverseProperty("Owner")]
        public virtual ICollection<Car> Car { get; set; }
    }
}
