using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnblockMe.Models
{
    public class StarRating
    {
        [Key]
        public int Id { get; set; }
        public int Rate { get; set; }
        public string IpAddress { get; set; }
        public string AspNetUserId { get; set; }
        [ForeignKey("AspNetUserId")]

        public virtual AspNetUsers user { get; set; }
    }
}
