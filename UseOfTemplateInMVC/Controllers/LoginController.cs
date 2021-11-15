using System;
using System.Web.Mvc;
using BusinessLogic.Repository;
using BusinessLogic.Models;
using BusinessLogic.Common;

namespace UseOfTemplateInMVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login obj)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    var userdetails = BusinessLogic.Repository.User.GetUserByUserName(obj.Name);
                    if (userdetails == null)
                    {
                        ViewBag.invalidMessage = Constants.IncorrectNameMessage;
                    }
                    else if (obj.Password != userdetails.Password)
                    {
                        ViewBag.invalidMessage = Constants.incorrectPasswordMessage;
                    }
                    else
                    {
                        Session["id"] = userdetails.UserId.ToString();
                        Session["name"] = userdetails.FirstName != null ? userdetails.FirstName.ToString() : "Guest";
                        Session["image"] = userdetails.ProfileImage != null ? userdetails.ProfileImage.ToString() :Url.Content(Constants.DefaultUserImage);
                        return this.RedirectToAction("Index", "Home");
                    }
                }
            }
            catch (Exception e)
            {

            }
            return View(obj);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return View("Login");
        }
    }
}
