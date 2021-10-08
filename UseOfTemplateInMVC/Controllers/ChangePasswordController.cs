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

        // GET: ChangeProfile
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePassword changePassword)
        {
            var userdetails = Registration.GetUserDetailsById(Convert.ToInt32(Session["id"]));
            if (userdetails.Password == changePassword.CurrentPassword)
            {
                userdetails.Password = changePassword.NewPassword;
                Registration.UpdatePassword(userdetails);
                ViewBag.Message =new string[2] { "0", Constants.UpdatePasswordMessage };
            }
            else
            {
                ViewBag.Message =new string[2]{"1", Constants.CurrentPasswordIncorrectMessage};
            }
            return View();
        }
    }
}