using IcerikYonetimSistemi.Data;
using IcerikYonetimSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IcerikYonetimSistemi.Areas.Yonetici.Controllers
{
    [Area("Yonetici")]
    public class SayfaController : Controller
    {
        private readonly ILogger<SayfaController> _logger;
        private readonly ApplicationDbContext _context;
        public SayfaController(ILogger<SayfaController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // CRUD - Create, Read, Update, Delete
        #region Okuma Islemleri

        public IActionResult Liste()
        {
            List<Sayfa> sayfalar = _context.Sayfa.ToList();
            return View(sayfalar);
        }

        public IActionResult Detay(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Sayfa sayfa = _context.Sayfa.FirstOrDefault(x => x.ID == id);

            if (sayfa == null)
                return NotFound();

            return View(sayfa);
        }

        #endregion

        #region Ekleme Islemleri

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Sayfa sayfa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Sayfa.Add(sayfa);
                    int sonuc = _context.SaveChanges();
                    if (sonuc >= 1)
                        return RedirectToAction(nameof(Liste));
                }
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Ekleme İşlemi Gerçekleştirilemedi - {Tarih}", DateTime.Now);
            }
            return View(sayfa);
        }

        #endregion

        #region Duzenleme Islemleri

        public IActionResult Duzenle(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Sayfa sayfa = _context.Sayfa.FirstOrDefault(x => x.ID == id);

            if (sayfa == null)
                return NotFound();

            return View(sayfa);
        }

        [HttpPost]
        public IActionResult Duzenle(int id, Sayfa sayfa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Sayfa _sayfa = _context.Sayfa.FirstOrDefault(x => x.ID == id);
                    _sayfa.Baslik = sayfa.Baslik;
                    _sayfa.EkAlan = sayfa.EkAlan;
                    _sayfa.Etkin = sayfa.Etkin;
                    _sayfa.MenuID = sayfa.MenuID;
                    _sayfa.SEODescription = sayfa.SEODescription;
                    _sayfa.SEOTitle = sayfa.SEOTitle;
                    int sonuc = _context.SaveChanges();
                    if (sonuc >= 1)
                        return RedirectToAction(nameof(Liste));
                }
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Duzenleme Islemi Gerceklestirilemedi! - {Tarih}", DateTime.Now);
            }
            return View(sayfa);
        }

        #endregion

        #region Silme Islemleri

        public IActionResult Sil(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Sayfa sayfa = _context.Sayfa.FirstOrDefault(x => x.ID == id);

            if (sayfa == null)
                return NotFound();

            return View(sayfa);
        }

        [HttpPost]
        public IActionResult Sil(int id, Sayfa sayfa)
        {
            try
            {
                Sayfa _sayfa = _context.Sayfa.FirstOrDefault(x => x.ID == id);
                _context.Sayfa.Remove(_sayfa);
                int sonuc = _context.SaveChanges();
                if (sonuc >= 1)
                    return RedirectToAction(nameof(Liste));
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Sil Islemi Gerceklestirilemedi! - {Tarih}", DateTime.Now);
            }
            return View(sayfa);
        }

        #endregion
    }
}
