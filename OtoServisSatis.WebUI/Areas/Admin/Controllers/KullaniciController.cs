using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KullaniciController : Controller
    {
        private readonly IService<Kullanici> _service;
        private readonly IService<Rol> _serviceRol;

        public KullaniciController(IService<Kullanici> service, IService<Rol> serviceRol)
        {
            _service = service;
            _serviceRol = serviceRol;
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
            ViewBag.Roller = new SelectList(_serviceRol.GetAll(), "Id", "Ad");
            return View();
        }

        // POST: KullaniciController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Add(kullanici);
                    _service.Save();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Model Hatası");
                }
            }

            ViewBag.Roller = new SelectList(_serviceRol.GetAll(), "Id", "Ad");
            return View();
        }

        // GET: KullaniciController/Edit/5
        public ActionResult Edit(int id)
        {
            var kullanici = _service.Find(id);
            ViewBag.Roller = new SelectList(_serviceRol.GetAll(), "Id", "Ad", kullanici.RolId);

            return View(kullanici);
        }

        // POST: KullaniciController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Kullanici kullanici)
        {
            if (id != kullanici.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var mevcutKullanici = _service.Find(id);
                if (mevcutKullanici == null) return NotFound();

                mevcutKullanici.Ad = kullanici.Ad;
                mevcutKullanici.Soyad = kullanici.Soyad;
                mevcutKullanici.Email = kullanici.Email;
                mevcutKullanici.Telefon = kullanici.Telefon;
                mevcutKullanici.KullaniciAdi = kullanici.KullaniciAdi;
                mevcutKullanici.RolId = kullanici.RolId;
                mevcutKullanici.Aktif = kullanici.Aktif;

                _service.Update(mevcutKullanici);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Roller = new SelectList(_serviceRol.GetAll(), "Id", "Ad", kullanici.RolId);
            return View(kullanici);
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
