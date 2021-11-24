using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Repository;
using BusinessLogic.Utility;
namespace UseOfTemplateInMVC.Controllers
{
    [AllowAnonymous]
    public class ConfirmEmailController : Controller
    {
        public ActionResult ConfirmEmail()
        {
            var pinCode = Request.QueryString["pinCode"].ToString();
            string status = Pincode.ConfirmUserByPinCode(Cryptography.Decryption(pinCode));
            return View((object)status);
        }

        [HttpPost]
        public JsonResult ResendEmailConfirmation(string userName)
        {
            var userData = Pincode.UserPinInfoByName(userName);
            if (userData == null)
            {
                return Json("incorrectUserName", JsonRequestBehavior.AllowGet);
            }
            else if (userData.IsConfirm == true)
            {
                return Json("alreadyConfirmedRegistration", JsonRequestBehavior.AllowGet);
            }
            else if (userData.IsConfirm == false)
            {
                var mailBody = "Thank you for registering with AdminLTE!! " + "<br>Please verify your email address by clicking " + "<a href='https://localhost:44369/ConfirmEmail/ConfirmEmail?pinCode=" + Cryptography.Encryption(userData.Pincode.ToString()) + "'>here.</a>" + "<br>Thank you, The AdminLTE Team.";
                EmailSender.SendEmail(userName, "Registration Confirmation Code", mailBody);
                return Json("resendConfirmationEmail", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
    }
}