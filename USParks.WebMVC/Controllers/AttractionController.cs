using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace USParks.WebMVC.Controllers
{
    public class AttractionController : Controller
    {
        // GET: Attraction
        public ActionResult Index()
        {
            return View();
        }
    }
}