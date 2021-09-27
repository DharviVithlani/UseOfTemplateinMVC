using System.Web.Mvc;

namespace UseOfTemplateInMVC.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
    }
}