using JansenAndSixel.Class;
using JansenAndSixel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace JansenAndSixel.Controllers
{
    public class OpenWeatherMapMvcController : Controller
    {
        // GET: OpenWeatherMapMvc
        public ActionResult Index()
        {
            OpenWeatherMap openWeatherMap = FillCity();
            return View(openWeatherMap);
        }

        // POST: OpenWeatherMapMVC
        [HttpPost]
        public ActionResult Index(OpenWeatherMap openWeatherMap, string cities)
        {
            openWeatherMap = FillCity();

            if(cities != null)
            {
                string apiKey = "b2661afe52833e45399208a3218ee120";
                HttpWebRequest apiRequest = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?id=" + cities + "&appid=" + apiKey + "&units=metric") as HttpWebRequest;
                string apiResponse = "";
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    apiResponse = reader.ReadToEnd();
                }

                ResponseWeather rootObject = JsonConvert.DeserializeObject<ResponseWeather>(apiResponse);

                StringBuilder sb = new StringBuilder();
                sb.Append("<table><tr><th>Weather Description</th></tr>");
                sb.Append("<tr><td>City:</td><td>" + rootObject.name + "</td></tr>");
                sb.Append("<tr><td>Country:</td><td>" + rootObject.sys.country + "</td></tr>");
                sb.Append("<tr><td>Wind:</td><td>" + rootObject.wind.speed + " Km/h</td></tr>");
                sb.Append("<tr><td>Current Temperature:</td><td>" + rootObject.main.temp + " °C</td></tr>");
                sb.Append("<tr><td>Humidity:</td><td>" + rootObject.main.humidity + "</td></tr>");
                sb.Append("<tr><td>Weather:</td><td>" + rootObject.weather[0].description + "</td></tr>");
                sb.Append("</table>");
                openWeatherMap.apiResponse = sb.ToString();
            }
            else
            {
                if(Request.Form["submit"] != null)
                {
                    openWeatherMap.apiResponse = "Select City";
                }
            }
            return View(openWeatherMap);
        }




        public OpenWeatherMap FillCity()
        {
            OpenWeatherMap openWeatherMap = new OpenWeatherMap();
            openWeatherMap.cities = new Dictionary<string, string>();
            openWeatherMap.cities.Add("Melbourne", "7839805");
            openWeatherMap.cities.Add("Auckland", "2193734");
            openWeatherMap.cities.Add("New Delhi", "1261481");
            openWeatherMap.cities.Add("Abu Dhabi", "292968");
            openWeatherMap.cities.Add("Lahore", "1172451");
            return openWeatherMap;
        }




    }
}