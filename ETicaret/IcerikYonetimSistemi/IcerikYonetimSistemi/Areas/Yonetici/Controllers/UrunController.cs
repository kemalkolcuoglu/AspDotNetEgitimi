using IslemKatmani;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarlikKatmani;

namespace IcerikYonetimSistemi.Areas.Yonetici.Controllers
{
    public class UrunController : TemelController
    {
        private readonly ILogger<UrunController> _logger;
        private readonly UrunService _urunIslemleri;
        private readonly KategoriService _kategoriIslemleri;
        public UrunController(ILogger<UrunController> logger, UrunService urunIslemleri, KategoriService kategoriIslemleri)
        {
            _logger = logger;
            _urunIslemleri = urunIslemleri;
            _kategoriIslemleri = kategoriIslemleri;
        }
        
        // CRUD - Create, Read, Update, Delete
        #region Okuma Islemleri

        public IActionResult Liste()
        {
            List<Urun> icerikler = _urunIslemleri.Listele();
            return View(icerikler);
        }

        public IActionResult Detay(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Urun icerik = _urunIslemleri.Bul(x => x.ID == id);

            if (icerik == null)
                return NotFound();

            return View(icerik);
        }

        #endregion

        #region Ekleme Islemleri

        public IActionResult Ekle()
        {
            ViewData["Kategoriler"] = new SelectList(_kategoriIslemleri.Listele(), nameof(Kategori.Id), nameof(Kategori.Baslik));
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Urun icerik)
        {
            if (ModelState.IsValid)
            {
                int sonuc = _urunIslemleri.Ekle(icerik);
                if (sonuc >= 1)
                    return RedirectToAction(nameof(Liste));
            }
            ViewData["Kategoriler"] = new SelectList(_kategoriIslemleri.Listele(), nameof(Kategori.Id), nameof(Kategori.Baslik));
            return View(icerik);
        }

        #endregion
        /*
        #region Duzenleme Islemleri

        public IActionResult Duzenle(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Urun icerik = _urunIslemleri.Bul(x => x.ID == id);

            if (icerik == null)
                return NotFound();

            ViewBag.Etiketler = new SelectList(_context.Etiket, nameof(Etiket.ID), nameof(Etiket.Baslik));
            ViewBag.Sayfalar = new SelectList(_context.Sayfa, nameof(Sayfa.ID), nameof(Sayfa.Baslik));
            return View(icerik);
        }

        [HttpPost]
        public IActionResult Duzenle(int id, Urun icerik)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int sonuc = 0;
                    Urun _icerik = _context.Urun.FirstOrDefault(x => x.ID == id);
                    _icerik.Baslik = icerik.Baslik;
                    _icerik.Detay = icerik.Detay;
                    _icerik.DuzenlemeTarihi = DateTime.Now;
                    _icerik.EkAlan = icerik.EkAlan;
                    _icerik.Etkin = icerik.Etkin;
                    _icerik.Gorsel = icerik.Gorsel;
                    _icerik.SayfaID = icerik.SayfaID;
                    _icerik.SEODescription = icerik.SEODescription;
                    _icerik.SEOTitle = icerik.SEOTitle;

                    //--------------------------------------------------------------------------------------------

                    if (sonuc >= 1)
                        return RedirectToAction(nameof(Liste));
                }
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Duzenleme Islemi Gerceklestirilemedi! - {Tarih}", DateTime.Now);
            }
            ViewBag.Etiketler = new SelectList(_context.Etiket, nameof(Etiket.ID), nameof(Etiket.Baslik));
            ViewBag.Sayfalar = new SelectList(_context.Sayfa, nameof(Sayfa.ID), nameof(Sayfa.Baslik));
            return View(icerik);
        }

        #endregion

        #region Silme Islemleri

        public IActionResult Sil(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Urun icerik = _urunIslemleri.Bul(x => x.ID == id);

            if (icerik == null)
                return NotFound();

            return View(icerik);
        }

        [HttpPost]
        public IActionResult Sil(int id, Urun icerik)
        {
            try
            {
                Urun _icerik = _urunIslemleri.Bul(x => x.ID == id);
                _context.Urun.Remove(_icerik);
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
        */
    }
}
