﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UseOfTemplateInMVC.Controllers
{
    public class MembersController : Controller
    {
        // GET: Members
        public ActionResult Members(string search)
        {
            var memberdata = BusinessLogic.Repository.Registration.GetMembers(search ?? "");
            return View(memberdata);
        }

        public ActionResult Delete(int id)
        {
            BusinessLogic.Repository.Registration.DeleteRow(id);
            return RedirectToAction("Members");
        }
    }
}