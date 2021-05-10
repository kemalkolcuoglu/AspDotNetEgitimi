using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VarlikKatmani;
using IslemKatmani;

namespace IcerikYonetimSistemi.Areas.Yonetici.Controllers
{
    public class MenuController : TemelController
    {
        private readonly ILogger<MenuController> _logger;
        private readonly MenuService _menuIslemleri;
        public MenuController(ILogger<MenuController> logger, MenuService menuIslemleri)
        {
            _logger = logger;
            _menuIslemleri = menuIslemleri;
        }

        // CRUD - Create, Read, Update, Delete
        #region Okuma Islemleri

        public IActionResult Liste()
        {
            List<Menu> menuler = _menuIslemleri.Listele();
            return View(menuler);
        }

        public IActionResult Detay(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Menu menu = _menuIslemleri.Bul(x => x.ID == id);

            if (menu == null)
                return NotFound();

            return View(menu);
        }

        #endregion

        #region Ekleme Islemleri

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Menu menu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int sonuc = _menuIslemleri.Ekle(menu);
                    if (sonuc >= 1)
                        return RedirectToAction(nameof(Liste));
                }
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Ekleme İşlemi Gerçekleştirilemedi - {Tarih}", DateTime.Now);
            }
            return View(menu);
        }

        #endregion

        #region Duzenleme Islemleri

        public IActionResult Duzenle(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Menu menu = _menuIslemleri.Bul(x => x.ID == id);

            if (menu == null)
                return NotFound();

            return View(menu);
        }

        [HttpPost]
        public IActionResult Duzenle(int id, Menu menu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Menu _menu = _menuIslemleri.Bul(x => x.ID == id);
                    _menu.AcilirMenuMu = menu.AcilirMenuMu;
                    _menu.Baslik = menu.Baslik;
                    _menu.EkAlan = menu.EkAlan;
                    _menu.Etkin = menu.Etkin;
                    _menu.Ikon = menu.Ikon;
                    int sonuc = _menuIslemleri.Guncele(_menu);
                    if (sonuc >= 1)
                        return RedirectToAction(nameof(Liste));
                }
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Duzenleme Islemi Gerceklestirilemedi! - {Tarih}", DateTime.Now);
            }
            return View(menu);
        }

        #endregion

        #region Silme Islemleri

        public IActionResult Sil(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Menu menu = _menuIslemleri.Bul(x => x.ID == id);

            if (menu == null)
                return NotFound();

            return View(menu);
        }

        [HttpPost]
        public IActionResult Sil(int id, Menu menu)
        {
            try
            {
                Menu _menu = _menuIslemleri.Bul(x => x.ID == id);
                int sonuc = _menuIslemleri.Sil(_menu);
                if (sonuc >= 1)
                    return RedirectToAction(nameof(Liste));
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Sil Islemi Gerceklestirilemedi! - {Tarih}", DateTime.Now);
            }
            return View(menu);
        }

        #endregion
    }
}
