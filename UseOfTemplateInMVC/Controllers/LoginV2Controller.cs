﻿using System;
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
                    return Json(new { isValid = false, errorMessage = "UserName is incorrect." }, JsonRequestBehavior.AllowGet);
                }
                else if (password != userdetails.Password)
                {
                    return Json(new { isValid = false, errorMessage = "Password is incorrect." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Session["id"] = userdetails.UserId.ToString();
                    Session["name"] = userdetails.FirstName != null ? userdetails.FirstName.ToString() : "Guest";
                    Session["image"] = userdetails.ProfileImage != null ? userdetails.ProfileImage.ToString() : Url.Content(Constants.DefaultUserImage);
                    return Json(new { isValid = true, errorMessage = "" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception e)
            {
                return Json(new { isValid = false, errorMessage = "Something went wrong." }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return View("LoginV2");
        }
    }
}