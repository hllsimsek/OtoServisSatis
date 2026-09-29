using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;
using Microsoft.AspNetCore.Identity;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KullaniciController : Controller
    {
        private readonly IService<Kullanici> _service;
        private readonly IService<Rol> _serviceRol;
        private readonly IPasswordHasher<Kullanici> _passwordHasher;

        public KullaniciController(IService<Kullanici> service, IService<Rol> serviceRol, IPasswordHasher<Kullanici> passwordHasher)
        {
            _service = service;
            _serviceRol = serviceRol;
            _passwordHasher = passwordHasher;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var kullanicilar = _service.GetAll();
            var roller = _serviceRol.GetAll();

            foreach (var item in kullanicilar)
            {
                item.Rol = roller.FirstOrDefault(r => r.Id == item.RolId);
            }

            return View(kullanicilar);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Roller = new SelectList(_serviceRol.GetAll(), "Id", "Ad");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    kullanici.Sifre = _passwordHasher.HashPassword(kullanici, kullanici.Sifre);
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

        public ActionResult Edit(int id)
        {
            var kullanici = _service.Find(id);
            ViewBag.Roller = new SelectList(_serviceRol.GetAll(), "Id", "Ad", kullanici.RolId);

            return View(kullanici);
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var kullanici = _service.Find(id);

            if (kullanici == null)
            {
                return NotFound();
            }

            try
            {
                _service.Delete(kullanici);
                _service.Save();                
            }
            catch
            {
                ModelState.AddModelError("", "Kullanıcı silinirken bir hata oluştu.");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
