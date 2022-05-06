using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using USParks.Models.ParkNature;
using USParks.Services;

namespace USParks.WebMVC.Controllers
{
    [Authorize]
    public class ParkNatureController : Controller
    {
        // GET: ParkNature
        public ActionResult Index()
        {
            var service = new ParkNatureService();
            var model = service.GetParkNature();
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
        public ActionResult Create(ParkNatureCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateParkNatureService();

            if (service.CreateParkNature(model))
            {
                TempData["SaveResult"] = "Nature was added to the park.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Nature couldn't be added to the park.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateParkNatureService();
            var model = svc.GetParkNatureById(id);

            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var service = CreateParkNatureService();
            var detail = service.GetParkNatureById(id);
            var model =
                new ParkNatureEdit()
                {
                    ParkNatureId = detail.ParkNatureId,
                    NatureId = detail.NatureId,
                    ParkId = detail.ParkId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ParkNatureEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ParkNatureId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateParkNatureService();
            

            if (service.UpdateParkNature(model))
            {
                TempData["SaveResult"] = "Nature was updated for the park.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Can't update another user's nature within a park.";
            return RedirectToAction("Index");
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateParkNatureService();
            var model = svc.GetParkNatureById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateParkNatureService();
            if (!service.DeleteParkNature(id))
            {
                TempData["Error"] = "Can't remove another user's nature from a park.";
                return RedirectToAction("Index");
            }
            service.DeleteParkNature(id);
            TempData["SaveResult"] = "Nature was removed from the park!";
            return RedirectToAction("Index");
        }

        private ParkNatureService CreateParkNatureService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ParkNatureService(userId);
            return service;
        }
    }
}