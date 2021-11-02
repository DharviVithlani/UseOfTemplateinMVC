using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Repository;
using BusinessLogic.Common;
using BusinessLogic.Utility;

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
                string mailBody = "Your Password is :" + userName.Password + "<br>Thank You.";
                EmailSender.SendEmail(username, Constants.SmtpForgorPasswordSubject, mailBody);
                return Json(true, JsonRequestBehavior.AllowGet);
            };
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}
