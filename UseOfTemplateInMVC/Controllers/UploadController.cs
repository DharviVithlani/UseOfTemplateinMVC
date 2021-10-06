using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Models;
using BusinessLogic.Repository;

namespace UseOfTemplateInMVC.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Upload(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Images/ProfileImages"), file.FileName);
                    file.SaveAs(_path);
                    Registration.UpdateUser(Convert.ToInt32(Session["id"]), file.FileName);
                    Session["image"] = file.FileName;
                }
            }
            catch (Exception e)
            {

            }
            return Json(file.FileName, JsonRequestBehavior.AllowGet);
        }
    }
}