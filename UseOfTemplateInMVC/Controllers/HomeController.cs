using System.Web.Mvc;

namespace UseOfTemplateInMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var productdata = BusinessLogic.Repository.Product.GetAllProducts();
            return View(productdata);
        }
    }
}









    