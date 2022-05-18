using System;
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
            if (!ModelState.IsValid) 
                return View(model);

            var service = CreateNatureService();
            HttpPostedFileBase file = Request.Files["ImageData"];
            int i = service.CreateNature(file, model);
            if (i == 1)
            {
                TempData["NatureSaveResult"] = "Nature was added.";
                return RedirectToAction("Index");
            }
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
                    Diet = (NatureEdit.DietType)detail.Diet,
                    Image = detail.Image
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NatureEdit model)
        {
            if (!ModelState.IsValid) 
                return View(model);

            if (model.NatureId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateNatureService();
            HttpPostedFileBase file = Request.Files["ImageData"];
            if (service.UpdateNature(file, model))
            {
                TempData["NatureSaveResult"] = "Nature was updated.";
                return RedirectToAction("Index");
            }
            TempData["NatureError"] = "Can't update another user's Nature item.";
            return RedirectToAction("Index");
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
                TempData["NatureError"] = "Can't delete another user's Nature item";
                return RedirectToAction("Index");
            }
            service.DeleteNature(id);
            TempData["NatureSaveResult"] = "Nature item was deleted";
            return RedirectToAction("Index");
        }

        private NatureService CreateNatureService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NatureService(userId);
            return service;
        }

        public ActionResult RetrieveImage(int id)
        {
            var service = CreateNatureService();

            byte[] cover = service.GetImageFromDataBase(id);
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }
    }
}