using Microsoft.AspNetCore.Mvc;
using Odevler.Data;
using Odevler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odevler.Controllers
{
    public class NotDefteriController : TemelController
    {
        public NotDefteriController(OdevContext context) : base(context)
        {
            _context = context;
        }

        public IActionResult Liste()
        {
            List<Not> notlar = _context.Not.OrderByDescending(x => x.Tarih).ToList();
            return View(notlar);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Not not)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    not.Tarih = DateTime.Now;
                    switch (not.Oncelik)
                    {
                        case 0:
                            not.Renk = "danger"; break;
                        case 1:
                            not.Renk = "warning"; break;
                        case 2:
                            not.Renk = "primary"; break;
                        default:
                            not.Renk = "light";
                            break;
                    }
                    _context.Not.Add(not);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Liste));
                }
            }
            catch (Exception exp)
            {
                ViewBag.Hata = exp.Message;
            }
            return View(not);
        }

        public IActionResult Sil(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Not not = _context.Not.FirstOrDefault(x => x.ID == id);

            if (not == null)
                return NotFound();

            return View(not);
        }

        [HttpPost]
        public IActionResult Sil(int id, Not sNot)
        {
            Not not = _context.Not.FirstOrDefault(x => x.ID == id);
            _context.Not.Remove(not);
            return RedirectToAction(nameof(Liste));
        }

    }
}
