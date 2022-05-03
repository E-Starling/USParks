using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using USParks.Models.Nature;
using USParks.Services;

namespace USParks.WebMVC.Controllers
{
    [Authorize]
    public class NatureController : Controller
    {
        // GET: Nature
        public ActionResult Index()
        {
            var model = new NatureListItem[0];
            return View(model);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NatureCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateNatureService();

            if (service.CreateNature(model))
            {
                TempData["SaveResult"] = "Your nature was created.";
                return RedirectToAction("Index");

            };
            ModelState.AddModelError("", "Note could not be created.");
            return View(model);
        }
    }
}