using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Narail.Controllers
{
    public class contactController : Controller
    {
        // GET: contact
        public ActionResult Index()
        {
            ViewBag.Title = "Narail | İletişim";
            return View();
        }
    }
}