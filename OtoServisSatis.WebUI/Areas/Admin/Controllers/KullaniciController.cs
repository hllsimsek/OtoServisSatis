using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KullaniciController : Controller
    {
        private readonly IService<Kullanici> _service;

        public KullaniciController(IService<Kullanici> service)
        {
            _service = service;
        }

        // GET: KullaniciController
        public ActionResult Index()
        {
            var kullanicilar = _service.GetAll();
            return View(kullanicilar);
        }

        // GET: KullaniciController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KullaniciController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KullaniciController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KullaniciController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KullaniciController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KullaniciController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KullaniciController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
