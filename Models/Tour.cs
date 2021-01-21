using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCompany.Models
{
    public class Tour
    {
        [Key]
        public int TourId { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
       
        public string ToursName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Country { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Description { get; set; }
       
        public double DaysCost { get; set; }

        public string ImgSrc { get; set; }

       

    }
}
