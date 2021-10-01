using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UseOfTemplateInMVC.Controllers
{
    public class MembersController : Controller
    {
        // GET: Members
        public ActionResult Members(string search, string command, string pSortOn, string sortby = "FullName", string sorttype = "asc")
        {
            if (sorttype.Equals("desc"))
                sorttype = "asc";
            else
                sorttype = "desc";

            if (!sortby.Equals(pSortOn, StringComparison.CurrentCultureIgnoreCase))
                sorttype = "asc";

            if (command == "Close")
            {
                var memberdata = BusinessLogic.Repository.Registration.GetMembers("", sortby, sorttype);
                ModelState.Clear();
                return View(memberdata);
            }
            else
            {
                var memberdata = BusinessLogic.Repository.Registration.GetMembers(search ?? "", sortby, sorttype);
                ViewBag.SortType = sorttype;
                ViewBag.SortBy = sortby;
                ViewBag.Search = search;
                return View(memberdata);
            }
        }

        public JsonResult Delete(int id, string search)
        {
            BusinessLogic.Repository.Registration.DeleteRow(id);
            var memberdata = BusinessLogic.Repository.Registration.GetMembers(search ?? "", "", "");
            return Json(memberdata.Count(), JsonRequestBehavior.AllowGet);
        }
    }
}