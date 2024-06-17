using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Org.BouncyCastle.Crypto.Macs;
using TravesalCore_Proje.Models;

namespace TravesalCore_Proje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressfrom = new MailboxAddress("Tunç", "traversalmail@gmail.com");
            mimeMessage.From.Add(mailboxAddressfrom);

            MailboxAddress mailboxAddressto = new MailboxAddress("User",mailRequest.ReceivertMail);
            mimeMessage.To.Add(mailboxAddressto);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = mailRequest.Subject;
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("traversalmail@gmail.com", "fechchctniogvmij");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }


    }
}
//traversalmail@gmail.com  fechchctniogvmij 123456Aa*