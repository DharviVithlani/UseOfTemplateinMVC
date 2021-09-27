using System;
using System.Web.Mvc;
using BusinessLogic.Repository;
using BusinessLogic.Models;

namespace UseOfTemplateInMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(login obj)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    var userdetails = Registration.GetUserByUserName(obj.Name);
                    if (userdetails == null)
                    {
                        ViewBag.invalidMessage = "Name is Incorrect.";
                    }
                    else if (obj.Password != userdetails.Password)
                    {
                        ViewBag.invalidMessage = "Password is Incorrect.";
                    }
                    else
                    {
                        Session["id"] = userdetails.UserId.ToString();
                        Session["name"] = userdetails.UserName.ToString();
                        return this.RedirectToAction("Index", "Home");
                    }
                }
            }
            catch(Exception e)
            {
               
            }
            return View(obj);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
    }
}