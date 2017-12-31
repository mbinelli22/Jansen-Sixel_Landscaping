using JansenAndSixel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace JansenAndSixel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Get newAppointments
        public ActionResult NewAppointment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewAppointment(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("mbinelli1996@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("michaeljordan@gmail.com");  // replace with valid value
                message.Subject = "New Appointment Request";
                message.Body = string.Format(body, appointment.FirstName, appointment.LastName, appointment.FromEmail, appointment.Address, appointment.PhoneNumber, appointment.ZipCode, appointment.Date, appointment.Time, appointment.ProjectType, appointment.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "michaeljordan@gmail.com",  // replace with valid value
                        Password = "Password2!"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(appointment);
        }

        public ActionResult Sent()
        {
            return View();
        }
    }
}