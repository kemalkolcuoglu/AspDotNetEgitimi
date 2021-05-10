using IcerikYonetimSistemi.Areas.Yonetici.Models;
using IslemKatmani.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IcerikYonetimSistemi.Areas.Yonetici.Controllers
{
    public class PanelController : TemelController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EmailGonder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EmailGonder(MailVM mailVM)
        {
            List<string> toList = mailVM.To.Split(",").ToList();

            bool sonuc = EmailHelper.SendMail(mailVM.Body, toList, mailVM.Subject);
            if (sonuc)
            {
                ViewBag.Durum = "Mail gönderme işlemi başarıyla gerçekleşti";
                return RedirectToAction(nameof(Index));
            }
            return View(mailVM);
        }

        public IActionResult SMSGonder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SMSGonder(SmsVM smsVM)
        {
            smsVM.Mesaj = smsVM.Mesaj.Replace(" ", "%20");
            smsVM.MesajBasligi = smsVM.MesajBasligi.Replace(" ", "%20");
            bool sonuc = SMSHelper.SMSGonder(smsVM.Gsmno, smsVM.MesajBasligi, smsVM.Mesaj);
            if (sonuc)
            {
                ViewBag.Durum = "Mail gönderme işlemi başarıyla gerçekleşti";
                return RedirectToAction(nameof(Index));
            }
            return View(smsVM);
        }
    }
}
