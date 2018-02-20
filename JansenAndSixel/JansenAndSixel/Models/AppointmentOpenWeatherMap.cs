using JansenAndSixel.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JansenAndSixel.Models
{
    public class AppointmentOpenWeatherMap
    {
        public Appointment appointment { get; set; }
        public ResponseWeather responseWeather { get; set; }

    }
}