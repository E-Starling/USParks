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

        public ActionResult Details(int id)
        {
            var svc = CreateNatureService();
            var model = svc.GetNatureById(id);

            return View(model);
        }

        
        public ActionResult Edit(int id)
        {
            var service = CreateNatureService();
            var detail = service.GetNatureById(id);
            var model =
                new NatureEdit()
                {
                    NatureId = detail.NatureId,
                    Name = detail.Name,
                    Description = detail.Description,
                    Kingdom = (NatureEdit.KingdomType)detail.Kingdom,
                    Class = detail.Class,
                    Diet = (NatureEdit.DietType)detail.Diet
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NatureEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.NatureId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateNatureService();

            if (service.UpdateNature(model))
            {
                TempData["SaveResult"] = "Nature was updated.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Can't update another user's Nature item.";
            return RedirectToAction("Index");
            //ModelState.AddModelError("", "Cant update other user's nature items.");
            //return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateNatureService();
            var model = svc.GetNatureById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateNatureService();
            if (!service.DeleteNature(id))
            {
                TempData["Error"] = "Can't delete another user's Nature item";
                return RedirectToAction("Index");
            }
            service.DeleteNature(id);
            TempData["SaveResult"] = "Nature item was deleted";
            return RedirectToAction("Index");
        }

        private NatureService CreateNatureService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NatureService(userId);
            return service;
        }
    }
}