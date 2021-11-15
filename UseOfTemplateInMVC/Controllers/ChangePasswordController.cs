using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Models;
using BusinessLogic.Repository;
using DataAccess;
using BusinessLogic.Common;
namespace UseOfTemplateInMVC.Controllers
{
    public class ChangePasswordController : Controller
    {
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ChangePassword(ChangePassword changePassword)
        {
            var userdetails = BusinessLogic.Repository.User.GetUserDetailsById(Convert.ToInt32(Session["id"]));
            if (userdetails.Password == changePassword.CurrentPassword)
            {
                if (userdetails.Password == changePassword.NewPassword)
                {
                    return Json(new { success = false, displayMethod = "warning" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    userdetails.Password = changePassword.NewPassword;
                    BusinessLogic.Repository.User.UpdatePassword(userdetails);
                    return Json(new { success = true, displayMethod = "success" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false, displayMethod = "error" }, JsonRequestBehavior.AllowGet);
        }
    }
}