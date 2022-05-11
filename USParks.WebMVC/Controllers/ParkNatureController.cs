using System.Web.Mvc;
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
                TempData["ParkNatureSaveResult"] = "Nature was added to the park.";
                return RedirectToAction("Index", "Park");
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
            }

            var service = CreateParkNatureService();

            if (service.UpdateParkNature(model))
            {
                TempData["ParkNatureSaveResult"] = "Nature was updated for the park.";
                return RedirectToAction("Index", "Park");
            }
            if (model.NatureId == id)
            {
                ModelState.AddModelError("", "Id wasn't updated");
            }
            if (model.NatureId != id)
            {
                ModelState.AddModelError("", "Please enter another valid nature id.");
            }

            return View(model);
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
            service.DeleteParkNature(id);
            TempData["ParkNatureSaveResult"] = "Nature was removed from the park!";
            return RedirectToAction("Index", "Park");
        }

        private ParkNatureService CreateParkNatureService()
        {
            var service = new ParkNatureService();
            return service;
        }
    }
}