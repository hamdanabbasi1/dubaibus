using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace dubaibus.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
       

        public ActionResult Booking(string name, string mail, string phone, string bookdate, string description, string bus)
        {

            var fromEmail = new MailAddress("admin@luxuryarttransport.com");
            var toEmail = new MailAddress("fawadbintariq3@gmail.com");
            var fromEmailPassword = "LuxuryTr@nsport9";
            MailMessage myMessage = new MailMessage();

            string subject = "Booking Request";
            string body = "<br/><br/><h2>Your have new booking Request!!</h2><br/><br/> <h1>FullName:</h1>" + name + "<br/><br/> <h1>Email:</h1>" + mail + "<br/><br/><h1>Phone:</h1>" + phone + "<br/><br/><h1>bookdate:</h1>" + bookdate + "<br/><br/><h1>Booking Transport:</h1>" + bus + "<br/><br/><h1>Booking Details:</h1>" + description;
            var smtp = new SmtpClient
            {
                Host = "smtpout.asia.secureserver.net",
                Port = 25,
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)

            };
            //relay-hosting.secureserver.net
            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            smtp.Send(message);
            smtp.Dispose();
            return RedirectToAction("Index");
        }

    }
}