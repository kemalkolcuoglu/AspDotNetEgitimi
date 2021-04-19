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
    public class IcerikController : Controller
    {
        private readonly ILogger<IcerikController> _logger;
        private readonly ApplicationDbContext _context;
        public IcerikController(ILogger<IcerikController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // CRUD - Create, Read, Update, Delete
        #region Okuma Islemleri

        public IActionResult Liste()
        {
            List<Icerik> icerikler = _context.Icerik.ToList();
            return View(icerikler);
        }

        public IActionResult Detay(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Icerik icerik = _context.Icerik.FirstOrDefault(x => x.ID == id);

            if (icerik == null)
                return NotFound();

            return View(icerik);
        }

        #endregion

        #region Ekleme Islemleri

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Icerik icerik)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    icerik.DuzenlemeTarihi = DateTime.Now;
                    icerik.EklemeTarihi = DateTime.Now;
                    _context.Icerik.Add(icerik);
                    int sonuc = _context.SaveChanges();
                    if (sonuc >= 1)
                        return RedirectToAction(nameof(Liste));
                }
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Ekleme İşlemi Gerçekleştirilemedi - {Tarih}", DateTime.Now);
            }
            return View(icerik);
        }

        #endregion

        #region Duzenleme Islemleri

        public IActionResult Duzenle(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Icerik icerik = _context.Icerik.FirstOrDefault(x => x.ID == id);

            if (icerik == null)
                return NotFound();

            return View(icerik);
        }

        [HttpPost]
        public IActionResult Duzenle(int id, Icerik icerik)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Icerik _icerik = _context.Icerik.FirstOrDefault(x => x.ID == id);
                    _icerik.Baslik = icerik.Baslik;
                    _icerik.Detay = icerik.Detay;
                    _icerik.DuzenlemeTarihi = DateTime.Now;
                    _icerik.EkAlan = icerik.EkAlan;
                    // TODO: Etiket Icerik icin duzenle islemini gerceklestir
                    _icerik.Etkin = icerik.Etkin;
                    _icerik.Gorsel = icerik.Gorsel;
                    _icerik.SayfaID = icerik.SayfaID;
                    _icerik.SEODescription = icerik.SEODescription;
                    _icerik.SEOTitle = icerik.SEOTitle;
                    int sonuc = _context.SaveChanges();
                    if (sonuc >= 1)
                        return RedirectToAction(nameof(Liste));
                }
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Duzenleme Islemi Gerceklestirilemedi! - {Tarih}", DateTime.Now);
            }
            return View(icerik);
        }

        #endregion

        #region Silme Islemleri

        public IActionResult Sil(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Icerik icerik = _context.Icerik.FirstOrDefault(x => x.ID == id);

            if (icerik == null)
                return NotFound();

            return View(icerik);
        }

        [HttpPost]
        public IActionResult Sil(int id, Icerik icerik)
        {
            try
            {
                Icerik _icerik = _context.Icerik.FirstOrDefault(x => x.ID == id);
                _context.Icerik.Remove(_icerik);
                int sonuc = _context.SaveChanges();
                if (sonuc >= 1)
                    return RedirectToAction(nameof(Liste));
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Sil Islemi Gerceklestirilemedi! - {Tarih}", DateTime.Now);
            }
            return View(icerik);
        }

        #endregion
    }
}
