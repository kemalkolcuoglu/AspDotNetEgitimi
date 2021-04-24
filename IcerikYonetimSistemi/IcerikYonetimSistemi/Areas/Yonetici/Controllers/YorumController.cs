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
    public class YorumController : Controller
    {
        private readonly ILogger<YorumController> _logger;
        private readonly ApplicationDbContext _context;
        public YorumController(ILogger<YorumController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // CRUD - Create, Read, Update, Delete
        #region Okuma Islemleri

        public IActionResult Liste()
        {
            List<Yorum> yorumlar = _context.Yorum.ToList();
            return View(yorumlar);
        }

        public IActionResult Detay(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Yorum yorum = _context.Yorum.FirstOrDefault(x => x.ID == id);

            if (yorum == null)
                return NotFound();

            return View(yorum);
        }

        #endregion

        #region Ekleme Islemleri

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Yorum yorum)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    yorum.Tarih = DateTime.Now;
                    _context.Yorum.Add(yorum);
                    int sonuc = _context.SaveChanges();
                    if (sonuc >= 1)
                        return RedirectToAction(nameof(Liste));
                }
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Ekleme İşlemi Gerçekleştirilemedi - {Tarih}", DateTime.Now);
            }
            return View(yorum);
        }

        #endregion

        #region Duzenleme Islemleri

        public IActionResult Duzenle(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Yorum yorum = _context.Yorum.FirstOrDefault(x => x.ID == id);

            if (yorum == null)
                return NotFound();

            return View(yorum);
        }

        [HttpPost]
        public IActionResult Duzenle(int id, Yorum yorum)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Yorum _yorum = _context.Yorum.FirstOrDefault(x => x.ID == id);
                    _yorum.Metin = yorum.Metin;
                    _yorum.IcerikID = yorum.IcerikID;
                    int sonuc = _context.SaveChanges();
                    if (sonuc >= 1)
                        return RedirectToAction(nameof(Liste));
                }
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Duzenleme Islemi Gerceklestirilemedi! - {Tarih}", DateTime.Now);
            }
            return View(yorum);
        }

        #endregion

        #region Silme Islemleri

        public IActionResult Sil(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Yorum yorum = _context.Yorum.FirstOrDefault(x => x.ID == id);

            if (yorum == null)
                return NotFound();

            return View(yorum);
        }

        [HttpPost]
        public IActionResult Sil(int id, Yorum yorum)
        {
            try
            {
                Yorum _yorum = _context.Yorum.FirstOrDefault(x => x.ID == id);
                _context.Yorum.Remove(_yorum);
                int sonuc = _context.SaveChanges();
                if (sonuc >= 1)
                    return RedirectToAction(nameof(Liste));
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Sil Islemi Gerceklestirilemedi! - {Tarih}", DateTime.Now);
            }
            return View(yorum);
        }

        #endregion
    }
}
