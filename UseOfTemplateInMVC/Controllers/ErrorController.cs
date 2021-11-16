using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UseOfTemplateInMVC.Controllers
{
    public class ErrorController : Controller
    {
        [AllowAnonymous]
        public ActionResult NotFound()
        {
            return PartialView("~/Views/Shared/Error.cshtml");
        }
    }
}