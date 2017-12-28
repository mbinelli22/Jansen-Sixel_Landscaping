using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JansenAndSixel.Models
{
    public class PhotoGallery
    {
        public PhotoGallery()
        {
            PhotoList = new List<string>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public List<string> PhotoList { get; set; }
    }
}