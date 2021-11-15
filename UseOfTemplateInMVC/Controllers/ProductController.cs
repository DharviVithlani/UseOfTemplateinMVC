using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Common;
using BusinessLogic.Models;
using BusinessLogic.Repository;
using DataAccess;

namespace UseOfTemplateInMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllProductDetails()
        {
            var productDetails = BusinessLogic.Repository.Product.GetAllProductDetails();
            return Json(new { data = productDetails }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Upsert(int? id)
        {
            if (id == null)
            {
                return View(new ProductData());
            }
            else
            {
                var productdetails =BusinessLogic.Repository.Product.GetProductByProductId(id);
                return View(productdetails);
            }
        }

        [HttpPost]
        public ActionResult Upsert(ProductData obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //if (System.Web.HttpContext.Current.Request.Files.Count > 0)
                    if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                    {
                        string ImageName = string.Empty;
                        var logo = System.Web.HttpContext.Current.Request.Files["file"];
                        if (logo.ContentLength > 0)
                        {
                            Guid guid = Guid.NewGuid();
                            var ext = Path.GetExtension(logo.FileName);
                            ImageName = Constants.productImagePath + guid.ToString() + ext;
                            if (obj.ProductId != 0)
                            {
                                var productdetails = BusinessLogic.Repository.Product.GetProductByProductId(obj.ProductId);
                                if (productdetails.ProductImage != ImageName)
                                {
                                    string filePath = Server.MapPath(productdetails.ProductImage);
                                    if (System.IO.File.Exists(filePath))
                                    {
                                        System.IO.File.Delete(filePath);
                                    }
                                }
                            }
                            obj.ProductImage = ImageName;
                            var comPath = Server.MapPath(ImageName);
                            logo.SaveAs(comPath);
                        }
                    }
                    BusinessLogic.Repository.Product.AddUpdateProducts(obj);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {

            }
            return View(obj);
        }

        public ActionResult Delete(int id)
        {
            var productData = BusinessLogic.Repository.Product.DeleteProduct(id);
            var imagePath = productData.ProductImage;
            string filePath = Server.MapPath(imagePath);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            return View("Index");
        }
    }
}