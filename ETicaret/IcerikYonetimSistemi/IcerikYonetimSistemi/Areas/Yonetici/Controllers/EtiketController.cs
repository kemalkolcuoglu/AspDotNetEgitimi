using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VarlikKatmani;
using IslemKatmani;

namespace IcerikYonetimSistemi.Areas.Yonetici.Controllers
{
    public class EtiketController : TemelController
    {
        private readonly ILogger<EtiketController> _logger;
        private readonly EtiketService _etiketIslemleri;
        public EtiketController(ILogger<EtiketController> logger, EtiketService etiketIslemleri)
        {
            _logger = logger;
            _etiketIslemleri = etiketIslemleri;
        }

        // CRUD - Create, Read, Update, Delete
        #region Okuma Islemleri

        public IActionResult Liste()
        {
            List<Etiket> etiketler = _etiketIslemleri.Listele();
            return View(etiketler);
        }

        public IActionResult Detay(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Etiket etiket = _etiketIslemleri.Bul(x => x.ID == id);

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
                    int sonuc = _etiketIslemleri.Ekle(etiket);
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

            Etiket etiket = _etiketIslemleri.Bul(x => x.ID == id);

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
                    Etiket _etiket = _etiketIslemleri.Bul(x => x.ID == id);
                    _etiket.Baslik = etiket.Baslik;
                    int sonuc = _etiketIslemleri.Guncele(_etiket);
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

            Etiket etiket = _etiketIslemleri.Bul(x => x.ID == id);

            if (etiket == null)
                return NotFound();

            return View(etiket);
        }

        [HttpPost]
        public IActionResult Sil(int id, Etiket etiket)
        {
            try
            {
                Etiket _etiket = _etiketIslemleri.Bul(x => x.ID == id);
                int sonuc = _etiketIslemleri.Sil(_etiket);
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
