using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using USParks.Data;
using USParks.Models.Park;
using USParks.Services;

namespace USParks.WebMVC.Controllers
{
    [Authorize]
    public class ParkController : Controller
    {
        // GET: Park
        public ActionResult Index()
        {
            var service = new ParkService();
            var model = service.GetPark();
            return View(model);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Create Park
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ParkCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateParkService();

            HttpPostedFileBase file = Request.Files["ImageData"];

            int i = service.CreatePark(file, model);
            if (i == 1)
            {
                TempData["ParkSaveResult"] = "Park was added.";
                return RedirectToAction("Index");

            }
            ModelState.AddModelError("", "Park could not be added.");


            return View(model);
        }

        public ActionResult Details(int id)
        { 
            var svc = CreateParkService();
            var model = svc.GetParkById(id);

            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var service = CreateParkService();
            var detail = service.GetParkById(id);
            var model =
                new ParkEdit()
                {
                    ParkId = detail.ParkId,
                    Name = detail.Name,
                    parkType = (ParkEdit.ParkType)detail.parkType,
                    Description = detail.Description,
                    Location = detail.Location,
                    Size = detail.Size,
                    YearlyVisitors = detail.YearlyVisitors,
                    Image = detail.Image
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ParkEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ParkId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateParkService();
            HttpPostedFileBase file = Request.Files["ImageData"];
            if (service.UpdatePark(file,model))
            {
                TempData["ParkSaveResult"] = "Park was updated.";
                return RedirectToAction("Index");
            }
            TempData["ParkError"] = "Can't update another user's Park.";
            return RedirectToAction("Index");
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateParkService();
            var model = svc.GetParkById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateParkService();
            if (!service.DeletePark(id))
            {
                TempData["ParkError"] = "Can't delete another user's Park.";
                return RedirectToAction("Index");
            }
            service.DeletePark(id);
            TempData["ParkSaveResult"] = "Park was deleted!";
            return RedirectToAction("Index");
        }

        private ParkService CreateParkService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ParkService(userId);
            return service;
        }

      
      

        public ActionResult RetrieveImage(int id)
        {
            var service = CreateParkService();
            
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