using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VarlikKatmani;
using IslemKatmani;

namespace IcerikYonetimSistemi.Areas.Yonetici.Controllers
{
    public class FormController : TemelController
    {
        private readonly ILogger<FormController> _logger;
        private readonly FormService _formIslemleri;
        public FormController(ILogger<FormController> logger, FormService formIslemleri)
        {
            _logger = logger;
            _formIslemleri = formIslemleri;
        }

        // CRUD - Create, Read, Update, Delete
        #region Okuma Islemleri

        public IActionResult Liste()
        {
            List<Form> formlar = _formIslemleri.Listele();
            return View(formlar);
        }

        public IActionResult Detay(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Form form = _formIslemleri.Bul(x => x.ID == id);

            if (form == null)
                return NotFound();

            return View(form);
        }

        #endregion

        #region Ekleme Islemleri

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Form form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int sonuc = _formIslemleri.Ekle(form);
                    if (sonuc >= 1)
                        return RedirectToAction(nameof(Liste));
                }
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Ekleme İşlemi Gerçekleştirilemedi - {Tarih}", DateTime.Now);
            }
            return View(form);
        }

        #endregion

        #region Duzenleme Islemleri

        public IActionResult Duzenle(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Form form = _formIslemleri.Bul(x => x.ID == id);

            if (form == null)
                return NotFound();

            return View(form);
        }

        [HttpPost]
        public IActionResult Duzenle(int id, Form form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Form _form = _formIslemleri.Bul(x => x.ID == id);
                    _form.AdSoyad = form.AdSoyad;
                    _form.Detay = form.Detay;
                    _form.EPosta = form.EPosta;
                    _form.Konu = form.Konu;
                    _form.Telefon = form.Telefon;
                    int sonuc = _formIslemleri.Guncele(_form);
                    if (sonuc >= 1)
                        return RedirectToAction(nameof(Liste));
                }
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Duzenleme Islemi Gerceklestirilemedi! - {Tarih}", DateTime.Now);
            }
            return View(form);
        }

        #endregion

        #region Silme Islemleri

        public IActionResult Sil(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Form form = _formIslemleri.Bul(x => x.ID == id);

            if (form == null)
                return NotFound();

            return View(form);
        }

        [HttpPost]
        public IActionResult Sil(int id, Form form)
        {
            try
            {
                Form _form = _formIslemleri.Bul(x => x.ID == id);
                int sonuc = _formIslemleri.Sil(_form);
                if (sonuc >= 1)
                    return RedirectToAction(nameof(Liste));
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Sil Islemi Gerceklestirilemedi! - {Tarih}", DateTime.Now);
            }
            return View(form);
        }

        #endregion
    }
}
