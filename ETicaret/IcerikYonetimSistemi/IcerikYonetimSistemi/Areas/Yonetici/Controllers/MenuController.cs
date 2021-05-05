using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IcerikYonetimSistemi.Data;
using IcerikYonetimSistemi.Models;
using Microsoft.Extensions.Logging;
using VarlikKatmani;

namespace IcerikYonetimSistemi.Areas.Yonetici.Controllers
{
    public class MenuController : TemelController
    {
        private readonly ILogger<MenuController> _logger;
        private readonly ApplicationDbContext _context;
        public MenuController(ILogger<MenuController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // CRUD - Create, Read, Update, Delete
        #region Okuma Islemleri

        public IActionResult Liste()
        {
            List<Menu> menuler = _context.Menu.ToList();
            return View(menuler);
        }

        public IActionResult Detay(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Menu menu = _context.Menu.FirstOrDefault(x => x.ID == id);

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
                    _context.Menu.Add(menu);
                    int sonuc = _context.SaveChanges();
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

            Menu menu = _context.Menu.FirstOrDefault(x => x.ID == id);

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
                    Menu _menu = _context.Menu.FirstOrDefault(x => x.ID == id);
                    _menu.AcilirMenuMu = menu.AcilirMenuMu;
                    _menu.Baslik = menu.Baslik;
                    _menu.EkAlan = menu.EkAlan;
                    _menu.Etkin = menu.Etkin;
                    _menu.Ikon = menu.Ikon;
                    int sonuc = _context.SaveChanges();
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

            Menu menu = _context.Menu.FirstOrDefault(x => x.ID == id);

            if (menu == null)
                return NotFound();

            return View(menu);
        }

        [HttpPost]
        public IActionResult Sil(int id, Menu menu)
        {
            try
            {
                Menu _menu = _context.Menu.FirstOrDefault(x => x.ID == id);
                _context.Menu.Remove(_menu);
                int sonuc = _context.SaveChanges();
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
