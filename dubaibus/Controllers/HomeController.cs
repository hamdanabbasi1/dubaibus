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
            var toEmail = new MailAddress("admin@luxuryarttransport.com");
            var fromEmailPassword = "LuxuryTr@nsport9";
            MailMessage myMessage = new MailMessage();

            string subject = "Booking Request";
            string body = "<br/><br/><h2>Your have new booking Request!!</h2><br/><br/> <h1>FullName:</h1>" + name + "<br/><br/> <h1>Email:</h1>" + mail + "<br/><br/><h1>Phone:</h1>" + phone + "<br/><br/><h1>bookdate:</h1>" + bookdate + "<br/><br/><h1>Booking Transport:</h1>" + bus + "<br/><br/><h1>Booking Details:</h1>" + description;


            MailMessage msg = new MailMessage(fromEmail, toEmail);
            msg.Subject = subject;
            msg.Body = body;
            msg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Host = "relay-hosting.secureserver.net";
            client.Port = 25;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("admin@luxuryarttransport.com", fromEmailPassword);
            //Send the msgs  
            client.Send(msg);
            client.Dispose();
            return RedirectToAction("Index");
        }

    }
}