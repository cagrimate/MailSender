using MailSender.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MailSender.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //we will use Index for sending mail. whenever we run the project your mail will be delivered

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;

            //------------------------------------------------------------------------->
            //please look at the READ.ME files. you can findthere different mail providers smtp settings.
            //------------------------------------------------------------------------->

            //---->>> 
            //smtp settings....
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("xyz@gmail.com|| YOUR MAİL ADDRESS", " YOUR PASSWORD");
            smtp.EnableSsl = true;
            smtp.Timeout = 10000; // means 10 sec. 1000.000 => 100 sec. try for 100 sec
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            //--->>>
            //mail settings
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("your mail address", "Your Name ");
            mail.To.Add("abc@gmail.com ; xyzt@asd.com ; ||| Addresses to which you want to send mail");
            //dont forget ---" "----  and ----- ; ----- between the addresses 
            mail.CC.Add("abc@gmail.com ; xyzt@asd.com ; ||| Addresses to which you want to send mail ");//CC => carbon copy
            mail.Bcc.Add("abc@gmail.com ; xyzt@asd.com ; ||| Addresses to which you want to send mail ");//BCC=> black carbon copy
            mail.Subject = "SUBJECT";
            mail.Body = "<h1> WHATEVER YOU WANT TO SAY </h1>";
            mail.IsBodyHtml = true;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;//for turkish you can find you language utf online
            mail.BodyEncoding = System.Text.Encoding.UTF8;////for turkish you can find you language utf online
            mail.Attachments.Add(new Attachment("E://Downloads/imgs/"));//if you want to add attachments you can use this
            //sending
            smtp.Send(mail);
            mail.Dispose();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
