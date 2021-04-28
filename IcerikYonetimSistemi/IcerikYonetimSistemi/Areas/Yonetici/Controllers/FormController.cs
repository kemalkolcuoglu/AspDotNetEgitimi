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

namespace IcerikYonetimSistemi.Areas.Yonetici.Controllers
{
    [Area("Yonetici")]
    public class FormController : Controller
    {
        private readonly ILogger<FormController> _logger;
        private readonly ApplicationDbContext _context;
        public FormController(ILogger<FormController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // CRUD - Create, Read, Update, Delete
        #region Okuma Islemleri

        public IActionResult Liste()
        {
            List<Form> formlar = _context.Form.ToList();
            return View(formlar);
        }

        public IActionResult Detay(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Form form = _context.Form.FirstOrDefault(x => x.ID == id);

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
                    _context.Form.Add(form);
                    int sonuc = _context.SaveChanges();
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

            Form form = _context.Form.FirstOrDefault(x => x.ID == id);

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
                    Form _form = _context.Form.FirstOrDefault(x => x.ID == id);
                    _form.AdSoyad = form.AdSoyad;
                    _form.Detay = form.Detay;
                    _form.EPosta = form.EPosta;
                    _form.Konu = form.Konu;
                    _form.Telefon = form.Telefon;
                    int sonuc = _context.SaveChanges();
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

            Form form = _context.Form.FirstOrDefault(x => x.ID == id);

            if (form == null)
                return NotFound();

            return View(form);
        }

        [HttpPost]
        public IActionResult Sil(int id, Form form)
        {
            try
            {
                Form _form = _context.Form.FirstOrDefault(x => x.ID == id);
                _context.Form.Remove(_form);
                int sonuc = _context.SaveChanges();
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
