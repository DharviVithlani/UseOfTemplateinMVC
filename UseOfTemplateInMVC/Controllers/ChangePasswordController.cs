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
            var userdetails = Registration.GetUserDetailsById(Convert.ToInt32(Session["id"]));
            if (userdetails.Password == changePassword.CurrentPassword)
            {
                userdetails.Password = changePassword.NewPassword;
                Registration.UpdatePassword(userdetails);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}