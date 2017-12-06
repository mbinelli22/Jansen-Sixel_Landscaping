using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JansenAndSixel.Models
{
    public class LandscapeProject
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Customer")]
        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual ApplicationUser Users { get; set; }

        [Display(Name ="Landscape Project Type")]
        public string ProjectType { get; set; }

        [Display(Name ="Landscape Project Discription")]
        public string ProjectDiscription { get; set; }


    }
}