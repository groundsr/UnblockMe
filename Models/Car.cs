using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UnblockMe.Models
{
    public partial class Car
    {
        [Key]
        [Column("license_plate")]
        [StringLength(20)]
        public string LicensePlate { get; set; }
        [Column("maker")]
        [StringLength(20)]
        public string Maker { get; set; }
        [Column("model")]
        [StringLength(20)]
        public string Model { get; set; }
        [Column("colour")]
        [StringLength(20)]
        public string Colour { get; set; }
        [Column("blocked_license_plate")]
        [StringLength(20)]
        public string BlockedLicensePlate { get; set; }
        [Column("blockedBy_license_plate")]
        [StringLength(20)]
        public string BlockedByLicensePlate { get; set; }
        [Column("owner_id")]
        public Guid? OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        [InverseProperty(nameof(User.Car))]
        public virtual User Owner { get; set; }
    }
}
