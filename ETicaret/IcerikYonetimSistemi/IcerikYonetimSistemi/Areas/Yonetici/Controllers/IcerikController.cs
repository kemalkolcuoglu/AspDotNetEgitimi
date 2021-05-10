using IslemKatmani;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using VarlikKatmani;

namespace IcerikYonetimSistemi.Areas.Yonetici.Controllers
{
    public class IcerikController : TemelController
    {
        private readonly ILogger<IcerikController> _logger;
        private readonly IcerikService _icerikIslemleri;
        private readonly SayfaService _sayfaIslemleri;
        private readonly EtiketService _etiketIslemleri;
        private readonly EtiketIcerikService _etiketIcerikIslemleri;

        public IcerikController(
            ILogger<IcerikController> logger,
            IcerikService icerikIslemleri,
            SayfaService sayfaIslemleri,
            EtiketService etiketIslemleri,
            EtiketIcerikService etiketIcerikIslemleri
        )
        {
            _logger = logger;
            _icerikIslemleri = icerikIslemleri;
            _etiketIslemleri = etiketIslemleri;
            _etiketIcerikIslemleri = etiketIcerikIslemleri;
            _sayfaIslemleri = sayfaIslemleri;
        }

        // CRUD - Create, Read, Update, Delete
        #region Okuma Islemleri

        public IActionResult Liste()
        {
            List<Icerik> icerikler = _icerikIslemleri.Listele();
            return View(icerikler);
        }

        public IActionResult Detay(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Icerik icerik = _icerikIslemleri.Bul(x => x.ID == id);

            if (icerik == null)
                return NotFound();

            return View(icerik);
        }

        #endregion

        #region Ekleme Islemleri

        public IActionResult Ekle()
        {
            ViewBag.Etiketler = new SelectList(_etiketIslemleri.Listele(), nameof(Etiket.ID), nameof(Etiket.Baslik));
            ViewBag.Sayfalar = new SelectList(_sayfaIslemleri.Listele(), nameof(Sayfa.ID), nameof(Sayfa.Baslik));
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Icerik icerik)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = _icerikIslemleri.TransactionOlustur())
                {
                    try
                    {
                        icerik.DuzenlemeTarihi = DateTime.Now;
                        icerik.EklemeTarihi = DateTime.Now;
                        int sonuc = _icerikIslemleri.Ekle(icerik);

                        foreach (var item in icerik.EtiketList)
                        {
                            EtiketIcerik ei = new EtiketIcerik()
                            {
                                IcerikID = icerik.ID,
                                EtiketID = item
                            };
                            _etiketIcerikIslemleri.KuyrugaEkle(ei);
                        }
                        sonuc = _etiketIcerikIslemleri.Kaydet();
                        if (sonuc >= 1)
                        {
                            transaction.Commit();
                            return RedirectToAction(nameof(Liste));
                        }
                        else
                            throw new Exception("Kaydedilemedi!");
                    }
                    catch (Exception exp)
                    {
                        transaction.Rollback();
                        _logger.LogError(exp, "Ekleme İşlemi Gerçekleştirilemedi - {Tarih}", DateTime.Now);
                    }
                }
            }
            ViewBag.Etiketler = new SelectList(_etiketIslemleri.Listele(), nameof(Etiket.ID), nameof(Etiket.Baslik));
            ViewBag.Sayfalar = new SelectList(_sayfaIslemleri.Listele(), nameof(Sayfa.ID), nameof(Sayfa.Baslik));
            return View(icerik);
        }

        #endregion

        #region Duzenleme Islemleri

        public IActionResult Duzenle(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            //Icerik icerik = _context.Icerik.FirstOrDefault(x => x.ID == id);
            Icerik icerik = _icerikIslemleri.Bul(x => x.ID == id);

            if (icerik == null)
                return NotFound();

            ViewBag.Etiketler = new SelectList(_etiketIslemleri.Listele(), nameof(Etiket.ID), nameof(Etiket.Baslik));
            ViewBag.Sayfalar = new SelectList(_sayfaIslemleri.Listele(), nameof(Sayfa.ID), nameof(Sayfa.Baslik));
            return View(icerik);
        }

        [HttpPost]
        public IActionResult Duzenle(int id, Icerik icerik)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int sonuc = 0;
                    Icerik _icerik = _icerikIslemleri.Bul(x => x.ID == id);
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
                    List<EtiketIcerik> etiketIcerik = _etiketIcerikIslemleri.ListeFiltre(x => x.IcerikID == id);
                    using (var transaction = _etiketIcerikIslemleri.TransactionOlustur())
                    {
                        try
                        {
                            _etiketIcerikIslemleri.CokluSil(etiketIcerik);
                            foreach (var item in icerik.EtiketList)
                            {
                                EtiketIcerik ei = new EtiketIcerik()
                                {
                                    IcerikID = id,
                                    EtiketID = item
                                };
                                _etiketIcerikIslemleri.KuyrugaEkle(ei);
                            }
                            sonuc = _etiketIcerikIslemleri.Kaydet();
                            transaction.Commit();
                        }
                        catch (Exception exp)
                        {
                            transaction.Rollback();
                            _logger.LogError(exp, "Duzenleme Islemi Gerceklestirilemedi - {Tarih}", DateTime.Now);
                        }
                    }
                    if (sonuc >= 1)
                        return RedirectToAction(nameof(Liste));
                }
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Duzenleme Islemi Gerceklestirilemedi! - {Tarih}", DateTime.Now);
            }
            ViewBag.Etiketler = new SelectList(_etiketIslemleri.Listele(), nameof(Etiket.ID), nameof(Etiket.Baslik));
            ViewBag.Sayfalar = new SelectList(_sayfaIslemleri.Listele(), nameof(Sayfa.ID), nameof(Sayfa.Baslik));
            return View(icerik);
        }

        #endregion

        #region Silme Islemleri

        public IActionResult Sil(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Icerik icerik = _icerikIslemleri.Bul(x => x.ID == id);

            if (icerik == null)
                return NotFound();

            return View(icerik);
        }

        [HttpPost]
        public IActionResult Sil(int id, Icerik icerik)
        {
            try
            {
                Icerik _icerik = _icerikIslemleri.Bul(x => x.ID == id);
                int sonuc = _icerikIslemleri.Sil(_icerik);
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
