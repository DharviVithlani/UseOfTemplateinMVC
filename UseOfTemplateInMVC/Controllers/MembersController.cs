using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Repository;
namespace UseOfTemplateInMVC.Controllers
{
    public class MembersController : Controller
    {
        // GET: Members
        public ActionResult Members(string search, string pSortOn, string sortby = "FullName", string sorttype = "asc")
         {
            if (sorttype.Equals("desc"))
                sorttype = "asc";
            else
                sorttype = "desc";

            if (!sortby.Equals(pSortOn, StringComparison.CurrentCultureIgnoreCase))
                sorttype = "asc";

            var memberdata = BusinessLogic.Repository.User.GetMembers(search ?? "", sortby, sorttype);
            ViewBag.SortType = sorttype;
            ViewBag.SortBy = sortby;
            ViewBag.Search = search;
            return View(memberdata);
        }

        public JsonResult Delete(int id, string search)
        {
            BusinessLogic.Repository.User.DeleteUser(id);
            var memberdata = BusinessLogic.Repository.User.GetMembers(search ?? "", "", "");
            return Json(memberdata.Count(), JsonRequestBehavior.AllowGet);
        }
    }
}