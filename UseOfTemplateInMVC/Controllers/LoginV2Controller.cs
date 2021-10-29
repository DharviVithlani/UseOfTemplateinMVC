using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Common;
using BusinessLogic.Repository;

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
                var userdetails = Registration.GetUserByUserName(username);
                if (userdetails == null)
                {
                    return Json(new { success = false, errorMessage = "UserName is incorrect.", id = 0 }, JsonRequestBehavior.AllowGet);
                }
                else if (userdetails.IsActive == false)
                {
                    Registration.AddLastLoginTimeStamp(userdetails.UserId, false);
                    return Json(new { success = false, errorMessage = "Your account is currently inactivated. Please contact your support team.", id = 0 }, JsonRequestBehavior.AllowGet);
                }
                else if (password != userdetails.Password)
                {
                    Registration.AddLastLoginTimeStamp(userdetails.UserId, false);
                    return Json(new { success = false, errorMessage = "Password is incorrect.", id = 0 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Session["id"] = userdetails.UserId.ToString();
                    Session["name"] = userdetails.FirstName != null ? userdetails.FirstName.ToString() : "Guest";
                    Session["image"] = userdetails.ProfileImage != null ? userdetails.ProfileImage.ToString() : Url.Content(Constants.DefaultUserImage);
                    Registration.AddLastLoginTimeStamp(userdetails.UserId, true);
                    return Json(new { success = true, errorMessage = "", id = userdetails.LastLoginTimeStamp == null ? userdetails.UserId : 0 }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(new { success = false, errorMessage = "Something went wrong.", id = 0 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return View("LoginV2");
        }
    }
}