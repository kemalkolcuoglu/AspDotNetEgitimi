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
using Microsoft.AspNetCore.Authorization;
using VarlikKatmani;

namespace IcerikYonetimSistemi.Areas.Yonetici.Controllers
{
    public class EtiketController : TemelController
    {
        private readonly ILogger<EtiketController> _logger;
        private readonly ApplicationDbContext _context;
        public EtiketController(ILogger<EtiketController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // CRUD - Create, Read, Update, Delete
        #region Okuma Islemleri

        public IActionResult Liste()
        {
            List<Etiket> etiketler = _context.Etiket.ToList();
            return View(etiketler);
        }

        public IActionResult Detay(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Etiket etiket = _context.Etiket.FirstOrDefault(x => x.ID == id);

            if (etiket == null)
                return NotFound();

            return View(etiket);
        }

        #endregion

        #region Ekleme Islemleri

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Etiket etiket)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Etiket.Add(etiket);
                    int sonuc = _context.SaveChanges();
                    if (sonuc >= 1)
                        return RedirectToAction(nameof(Liste));
                }
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Ekleme İşlemi Gerçekleştirilemedi - {Tarih}", DateTime.Now);
            }
            return View(etiket);
        }

        #endregion

        #region Duzenleme Islemleri

        public IActionResult Duzenle(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Etiket etiket = _context.Etiket.FirstOrDefault(x => x.ID == id);

            if (etiket == null)
                return NotFound();

            return View(etiket);
        }

        [HttpPost]
        public IActionResult Duzenle(int id, Etiket etiket)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Etiket _etiket = _context.Etiket.FirstOrDefault(x => x.ID == id);
                    _etiket.Baslik = etiket.Baslik;
                    int sonuc = _context.SaveChanges();
                    if (sonuc >= 1)
                        return RedirectToAction(nameof(Liste));
                }
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Duzenleme Islemi Gerceklestirilemedi! - {Tarih}", DateTime.Now);
            }
            return View(etiket);
        }

        #endregion

        #region Silme Islemleri

        public IActionResult Sil(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Etiket etiket = _context.Etiket.FirstOrDefault(x => x.ID == id);

            if (etiket == null)
                return NotFound();

            return View(etiket);
        }

        [HttpPost]
        public IActionResult Sil(int id, Etiket etiket)
        {
            try
            {
                Etiket _etiket = _context.Etiket.FirstOrDefault(x => x.ID == id);
                _context.Etiket.Remove(_etiket);
                int sonuc = _context.SaveChanges();
                if (sonuc >= 1)
                    return RedirectToAction(nameof(Liste));
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Sil Islemi Gerceklestirilemedi! - {Tarih}", DateTime.Now);
            }
            return View(etiket);
        }

        #endregion
    }
}
