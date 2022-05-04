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
            // Code for only seeing what user created??
            //var userId = Guid.Parse(User.Identity.GetUserId());
            //var service = new NatureService(userId);
            //var model = service.GetNature();
            //return View(model);
            var service = new NatureService();
            var model = service.GetNature();
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
            //if (!ModelState.IsValid) return View(model);

            //var service = CreateNatureService();

            //if (service.CreateNature(model))
            //{
            //    TempData["SaveResult"] = "Your nature was created.";
            //    return RedirectToAction("Index");

            //};
            //ModelState.AddModelError("", "Note could not be created.");
            //return View(model);

            if (!ModelState.IsValid) return View(model);

            var service = CreateNatureService();

            if (service.CreateNature(model))
            {
                TempData["SaveResult"] = "Nature was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Nature could not be added.");

            return View(model);
        }

        private NatureService CreateNatureService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NatureService(userId);
            return service;
        }
    }
}