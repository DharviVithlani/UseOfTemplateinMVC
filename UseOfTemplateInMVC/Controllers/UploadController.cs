using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Models;
using BusinessLogic.Repository;
using BusinessLogic.Common;

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
                if (Convert.ToString(Session["image"]) != Constants.DefaultUserImage)
                {
                    string filePath = Server.MapPath(Convert.ToString(Session["image"]));
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
                if (file.ContentLength > 0)
                {
                    string ImageName = string.Empty;
                    Guid guid = Guid.NewGuid();
                    var ext = Path.GetExtension(file.FileName);
                    ImageName = Constants.profileImagePath + guid.ToString() + ext;
                    var comPath = Server.MapPath(ImageName);
                    file.SaveAs(comPath);
                    BusinessLogic.Repository.User.UpdateUserProfile(Convert.ToInt32(Session["id"]), ImageName);
                    Session["image"] = ImageName;
                }
            }
            catch (Exception e)
            {

            }
            return Json(Session["image"], JsonRequestBehavior.AllowGet);
        }
    }
}