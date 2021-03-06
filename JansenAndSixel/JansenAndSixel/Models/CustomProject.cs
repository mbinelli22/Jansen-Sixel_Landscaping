﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JansenAndSixel.Models
{
    public class CustomProject
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Your Name:")]
        public string Name { get; set; }
        
        [Display(Name = "Phone Number:")]
        public string PhoneNumber { get; set; }

        [Display(Name ="Email:")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name ="Type of Project:")]
        public string TypeOfProject { get; set; }

        [Display(Name ="Type of Landscaping Project:")]
        public string TypeOfLandscapeProject { get; set; }

        [Display(Name ="Type of Hardscaping Project:")]
        public string TypeOfHardscapeProject { get; set; }

        [Display(Name ="Type of Material:")]
        public string TypeOfMaterial { get; set; }

        [Display(Name = "Quantity of Material:")]
        public string QuantityOfMaterial { get; set; }

        [Display(Name ="Location of Project:")]
        public string Location { get; set; }



    }
}