using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UnblockMe.Models
{
    public partial class Location
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("lat")]
        [StringLength(50)]
        public string Lat { get; set; }
        [Column("lng")]
        [StringLength(50)]
        public string Lng { get; set; }
    }
}
