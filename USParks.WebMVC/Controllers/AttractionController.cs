using System.Web;
using System.Web.Mvc;
using USParks.Models.Attraction;
using USParks.Services;

namespace USParks.WebMVC.Controllers
{
    [Authorize]
    public class AttractionController : Controller
    {
        // GET: Attraction
        public ActionResult Index()
        {
            var service = new AttractionService();
            var model = service.GetAttraction();
            return View(model);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Create Attraction
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AttractionCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var service = CreateAttractionService();
            HttpPostedFileBase file = Request.Files["ImageData"];
            int i = service.CreateAttraction(file, model);
            if (i == 1)
            {
                TempData["AttractionSaveResult"] = "Attraction was added.";
                return RedirectToAction("Index", "Park");
            }
            ModelState.AddModelError("", "Invalid Park Id.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateAttractionService();
            var model = svc.GetAttractionById(id);

            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var service = CreateAttractionService();
            var detail = service.GetAttractionById(id);
            var model =
                new AttractionEdit()
                {
                    AttractionId = detail.AttractionId,
                    Name = detail.Name,
                    Description = detail.Description,
                    ParkId = detail.ParkId,
                    Image = detail.Image
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AttractionEdit model)
        {

            if (!ModelState.IsValid) 
                return View(model);

            if (model.AttractionId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAttractionService();
            HttpPostedFileBase file = Request.Files["ImageData"];
            if (service.UpdateAttraction(file, model))
            {
                TempData["AttractionSaveResult"] = "Attraction was updated.";
                return RedirectToAction("Index", "Park");
            }
            TempData["AttractionError"] = "Editing Error";
            return RedirectToAction("Index", "Park");

        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAttractionService();
            var model = svc.GetAttractionById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAttractionService();
            if (!service.DeleteAttraction(id))
            {
                TempData["AttractionError"] = "Deletion Error.";
                return RedirectToAction("Index", "Park");
            }
            service.DeleteAttraction(id);
            TempData["AttractionSaveResult"] = "Attraction was deleted!";
            return RedirectToAction("Index", "Park");
        }

        private AttractionService CreateAttractionService()
        {
            var service = new AttractionService();
            return service;
        }

        public ActionResult RetrieveImage(int id)
        {
            var service = CreateAttractionService();

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