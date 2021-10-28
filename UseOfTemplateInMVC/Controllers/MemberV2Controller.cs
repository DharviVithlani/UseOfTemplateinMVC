using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Models;
using BusinessLogic.Repository;

namespace UseOfTemplateInMVC.Controllers
{
    public class MemberV2Controller : Controller
    {
        // GET: MemberV2
        public ActionResult MemberV2()
        {
            return View();
        }
        public JsonResult GetData()
        {
            var userdetails = Registration.GetAllUsers();
            return Json(new { data = userdetails}, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int id)
        {
            Registration.DeleteRow(id);
            var userdetails = Registration.GetAllUsers();
            return Json(userdetails.Count(), JsonRequestBehavior.AllowGet);
        }
    }
}