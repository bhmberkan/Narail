using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Narail.Controllers
{
    public class BlogAdminController : Controller
    {
        // GET: BlogAdmin
        public ActionResult Index()
        {
            ViewBag.Title = "Narail | Blog Admin";
            return View();
        }
    }
}