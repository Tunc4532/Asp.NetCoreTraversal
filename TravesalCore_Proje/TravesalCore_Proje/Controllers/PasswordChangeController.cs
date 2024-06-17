using AutoMapper.Internal;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TravesalCore_Proje.Models;

namespace TravesalCore_Proje.Controllers
{
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            var user = await _userManager.FindByEmailAsync(forgetPasswordViewModel.Mail);
            string passwordresettoken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var pasvordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
            {
                userid = user.Id,
                token = passwordresettoken
            }, HttpContext.Request.Scheme);

            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressfrom = new MailboxAddress("Tunç", "traversalmail@gmail.com");
            mimeMessage.From.Add(mailboxAddressfrom);

            MailboxAddress mailboxAddressto = new MailboxAddress("User", forgetPasswordViewModel.Mail);
            mimeMessage.To.Add(mailboxAddressto);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = pasvordResetTokenLink;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "Şifre Değişiklik Talebi";

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("traversalmail@gmail.com", "fechchctniogvmij");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userid, string token)
        {
            TempData["userid"] = userid;
            TempData["token"] = token;


            return View();
        }

        [HttpPost]
        public async Task <IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            var userid = TempData["userid"];
            var  token = TempData["token"];
            if(userid == null || token == null)
            {
                //error message
            }
            var user = await _userManager.FindByIdAsync(userid.ToString());
            var result = await _userManager.ResetPasswordAsync(user, token.ToString(),resetPasswordViewModel.Password);
            if(result.Succeeded)
            {
                return RedirectToAction("SıgnIn", "Login");
            }

            return View();
        }
    }
}
