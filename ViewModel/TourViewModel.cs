using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCompany.ViewModel
{
    public class TourViewModel
    {
        public int TourId { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Tour Name")]
        public string ToursName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Country { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Description { get; set; }
        [DisplayName("Day Cost")]
        public double DaysCost { get; set; }

        [DisplayName("Image")]
        public string ImgSrc { get; set; }
        public IFormFile uploadedFile { get; set; }
        
    }
}
