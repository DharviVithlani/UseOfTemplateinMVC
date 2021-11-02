using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Common;
using BusinessLogic.Repository;
using DataAccess;
using BusinessLogic.Utility;

namespace UseOfTemplateInMVC.Controllers
{
    [AllowAnonymous]
    public class LoginV2Controller : Controller
    {
        public ActionResult LoginV2()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LoginV2(string username, string password)
        {
            try
            {
                User user = new User();
                var userdetails = Registration.GetUserByUserName(username);
                if (userdetails == null)
                {
                    return Json(new
                    {
                        success = false,
                        errorMessage = "UserName is incorrect.",
                        id = 0,
                        IsBlocked = false
                    }, JsonRequestBehavior.AllowGet);
                }
                else if (userdetails.IsActive == false)
                {
                    return Json(new
                    {
                        success = false,
                        errorMessage = "Your account is currently inactivated. Please contact your support team.",
                        id = 0,
                        IsBlocked = false
                    }, JsonRequestBehavior.AllowGet);
                }
                else if (password != userdetails.Password)
                {
                    user = Registration.AddLastLoginTimeStamp(userdetails.UserId, false);
                    if (user.LoginFailedCount < 6)
                    {
                        string mailBody = "Your account has been disabled temporarily for 24 hour, please contact customer support.";
                        EmailSender.SendEmail(username, Constants.SmtpLoginAttemptSubject, mailBody);
                    }
                    return Json(new
                    {
                        success = false,
                        errorMessage = "Password is incorrect.",
                        id = 0,
                        IsBlocked = user.LoginFailedCount > 5
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    user = Registration.AddLastLoginTimeStamp(userdetails.UserId, true);
                    if (user.IsBlock != true)
                    {
                        SetSession(user);
                    }
                    return Json(new
                    {
                        success = !user.IsBlock,
                        errorMessage = "",
                        id = userdetails.LastLoginTimeStamp == null ? userdetails.UserId : 0,
                        IsBlocked = user.LoginFailedCount > 5
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(new { success = false, errorMessage = "Something went wrong.", id = 0, loginfailedcount = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        void SetSession(User userdetails)
        {
            Session["id"] = userdetails.UserId.ToString();
            Session["name"] = userdetails.FirstName != null ? userdetails.FirstName.ToString() : "Guest";
            Session["image"] = userdetails.ProfileImage != null ? userdetails.ProfileImage.ToString() : Url.Content(Constants.DefaultUserImage);
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return View("LoginV2");
        }
    }
}