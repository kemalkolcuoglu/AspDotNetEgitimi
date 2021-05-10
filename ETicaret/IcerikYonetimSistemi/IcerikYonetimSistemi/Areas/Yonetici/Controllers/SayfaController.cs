using IslemKatmani;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using VarlikKatmani;

namespace IcerikYonetimSistemi.Areas.Yonetici.Controllers
{
    public class SayfaController : TemelController
    {
        private readonly ILogger<SayfaController> _logger;
        private readonly IslemRepository<Sayfa> _sayfaIslemleri;
        private readonly MenuService _menuIslemleri;
        public SayfaController(ILogger<SayfaController> logger, SayfaService sayfaIslemleri, MenuService menuIslemleri)
        {
            _logger = logger;
            _sayfaIslemleri = sayfaIslemleri;
            _menuIslemleri = menuIslemleri;
        }

        // CRUD - Create, Read, Update, Delete
        #region Okuma Islemleri

        public IActionResult Liste()
        {
            List<Sayfa> sayfalar = _sayfaIslemleri.Sorgu().Include(x => x.Menu).ToList();
            return View(sayfalar);
        }

        public IActionResult Detay(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Sayfa sayfa = _sayfaIslemleri.Bul(x => x.ID == id);

            if (sayfa == null)
                return NotFound();

            return View(sayfa);
        }

        #endregion

        #region Ekleme Islemleri

        public IActionResult Ekle()
        {
            ViewBag.Menuler = new SelectList(_menuIslemleri.Listele(), nameof(Menu.ID), nameof(Menu.Baslik));
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Sayfa sayfa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int sonuc = _sayfaIslemleri.Ekle(sayfa);
                    if (sonuc >= 1)
                        return RedirectToAction(nameof(Liste));
                }
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Ekleme İşlemi Gerçekleştirilemedi - {Tarih}", DateTime.Now);
            }
            ViewBag.Menuler = new SelectList(_menuIslemleri.Listele(), nameof(Menu.ID), nameof(Menu.Baslik));
            return View(sayfa);
        }

        #endregion

        #region Duzenleme Islemleri

        public IActionResult Duzenle(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Sayfa sayfa = _sayfaIslemleri.Bul(x => x.ID == id);

            if (sayfa == null)
                return NotFound();

            ViewBag.Menuler = new SelectList(_menuIslemleri.Listele(), nameof(Menu.ID), nameof(Menu.Baslik));

            return View(sayfa);
        }

        [HttpPost]
        public IActionResult Duzenle(int id, Sayfa sayfa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Sayfa _sayfa = _sayfaIslemleri.Bul(x => x.ID == id);
                    _sayfa.Baslik = sayfa.Baslik;
                    _sayfa.EkAlan = sayfa.EkAlan;
                    _sayfa.Etkin = sayfa.Etkin;
                    _sayfa.MenuID = sayfa.MenuID;
                    _sayfa.SEODescription = sayfa.SEODescription;
                    _sayfa.SEOTitle = sayfa.SEOTitle;
                    int sonuc = _sayfaIslemleri.Guncele(_sayfa);
                    if (sonuc >= 1)
                        return RedirectToAction(nameof(Liste));
                }
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Duzenleme Islemi Gerceklestirilemedi! - {Tarih}", DateTime.Now);
            }
            ViewBag.Menuler = new SelectList(_menuIslemleri.Listele(), nameof(Menu.ID), nameof(Menu.Baslik));
            return View(sayfa);
        }

        #endregion

        #region Silme Islemleri

        public IActionResult Sil(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Sayfa sayfa = _sayfaIslemleri.Bul(x => x.ID == id);

            if (sayfa == null)
                return NotFound();

            return View(sayfa);
        }

        [HttpPost]
        public IActionResult Sil(int id, Sayfa sayfa)
        {
            try
            {
                Sayfa _sayfa = _sayfaIslemleri.Bul(x => x.ID == id);
                int sonuc = _sayfaIslemleri.Sil(_sayfa);
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
