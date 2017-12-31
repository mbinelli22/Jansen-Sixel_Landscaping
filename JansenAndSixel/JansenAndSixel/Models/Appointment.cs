using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JansenAndSixel.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required, Display(Name = "Your email"), EmailAddress]
        public string FromEmail { get; set; }

        [Required]
        [Display(Name ="Date of appointment")]
        public string Date { get; set; }

        [Required]
        [Display(Name = "Time of appointment")]
        public string Time { get; set; }

        [Required]
        [Display(Name = "Landscape Project Type")]
        public string ProjectType { get; set; }

        [Required]
        public string Message { get; set; }
    }
}