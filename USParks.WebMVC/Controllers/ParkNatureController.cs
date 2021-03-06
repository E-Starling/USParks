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
        // POST: Create ParkNature
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
            if (!service.CreateParkNature(model))
            {
                ModelState.AddModelError("", "The Nature already is in the park!");
                return View(model);
            }

            
            ModelState.AddModelError("", "Nature couldn't be added to the park.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateParkNatureService();
            var model = svc.GetParkNatureById(id);

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

        public ActionResult RetrieveImage(int id)
        {
            var service = CreateParkNatureService();

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