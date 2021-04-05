using Microsoft.AspNetCore.Mvc;
using Odevler.Data;
using Odevler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odevler.Controllers
{
    public class AnketController : TemelController
    {
        public AnketController(OdevContext context) : base(context)
        {
            _context = context;
        }

        public IActionResult Soru()
        {
            List<Anket> anketler = _context.Anket.ToList();
            if(anketler.Count != 0)
            {
                Random rnd = new Random();
                int sayi = rnd.Next(0, anketler.Count);

                return View(anketler[sayi]);
            }
            return RedirectToAction(nameof(Ekle));
        }

        [HttpPost]
        public IActionResult Soru(Anket anket)
        {
            try
            {

                Sonuc sonuc = new Sonuc()
                {
                    SoruID = anket.ID
                };
                if (anket.A)
                    sonuc.Cevap = 1;
                if (anket.B)
                    sonuc.Cevap = 2;
                if (anket.C)
                    sonuc.Cevap = 3;
                if (anket.D)
                    sonuc.Cevap = 4;
                _context.Sonuc.Add(sonuc);
                _context.SaveChanges();
            }
            catch (Exception exp)
            {
                ViewBag.Hata = exp.Message;
            }
            return RedirectToAction(nameof(Soru));
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Anket anket)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    anket.Tarih = DateTime.Now;
                    _context.Anket.Add(anket);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Soru));
                }
            }
            catch (Exception exp)
            {
                ViewBag.Hata = exp.Message;
            }
            return View(anket);
        }
    }
}
