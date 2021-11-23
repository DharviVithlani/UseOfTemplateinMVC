using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Repository;
using BusinessLogic.Utility;
namespace UseOfTemplateInMVC.Controllers
{
    
    public class ConfirmEmailController : Controller
    {
        // GET: ConfirmRegistration
        [AllowAnonymous]
        public ActionResult ConfirmEmail()
        {
            var pinCode = Request.QueryString["pinCode"].ToString();
            string status = Pincode.ConfirmUserByPinCode(Cryptography.Decryption(pinCode));
            return View((object)status);
        }
    }
}