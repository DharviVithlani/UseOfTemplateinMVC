using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Repository;
using BusinessLogic.Common;
namespace UseOfTemplateInMVC.Controllers
{
    public class ForgotPasswordController : Controller
    {
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult ForgotPassword(string username)
        {
            var userName = Registration.GetUserByUserName(username);
            if (userName != null)
            {
                var smtpClient = new SmtpClient(Constants.SmtpClient)
                {
                    Port = 587,
                    Credentials = new NetworkCredential(Constants.SmtpUserName, Constants.SmtpPassword),
                    EnableSsl = true,
                };
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(Constants.SmtpSystemUserName),
                    Subject = Constants.SmtpMailSubject,
                    Body = "Your Password is :" + userName.Password + "<br>Thank You.",
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(userName.UserName);
                smtpClient.Send(mailMessage);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}