using Microsoft.AspNetCore.Mvc;
using Odevler.Data;
using Odevler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odevler.Controllers
{
    public class BlogController : Controller
    {
        OdevContext _context;

        public BlogController(OdevContext context)
        {
            _context = context;
        }

        public IActionResult Liste()
        {
            List<Blog> bloglar = _context.Blog.OrderByDescending(x => x.Tarih).ToList();
            ViewData["context"] = _context;
            return View(bloglar);
        }

        public IActionResult Detay(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));
            Blog blog = _context.Blog.FirstOrDefault(x => x.ID == id);
            if (blog == null)
                return NotFound();
            return View(blog);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Blog blog)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    blog.Tarih = DateTime.Now;
                    _context.Blog.Add(blog);
                    int sonuc = _context.SaveChanges();

                    if (sonuc == 1)
                    {
                        return RedirectToAction(nameof(BlogController.Liste));
                    }
                    ViewBag.Hata = "Veri kaydetme işlemi gerçekleştirilemedi";
                }
            }
            catch (Exception exp)
            {
                ViewBag.Hata = exp.Message;
            }
            return View(blog);
        }

        [HttpGet]
        public IActionResult Duzenle(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Blog blog = _context.Blog.FirstOrDefault(x => x.ID == id);

            if (blog == null)
                return NotFound();

            return View("Ekle", blog);
        }

        [HttpPost]
        public IActionResult Duzenle(int id, Blog yeniBlog)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Blog blog = _context.Blog.FirstOrDefault(x => x.ID == id);
                    blog.Baslik = yeniBlog.Baslik;
                    blog.Icerik = yeniBlog.Icerik;
                    blog.Yazar = yeniBlog.Yazar;
                    int sonuc = _context.SaveChanges();

                    if (sonuc == 1)
                    {
                        return RedirectToAction(nameof(BlogController.Liste));
                    }
                    ViewBag.Hata = "Veri kaydetme işlemi gerçekleştirilemedi";
                }
            }
            catch (Exception exp)
            {
                ViewBag.Hata = exp.Message;
            }
            return View("Ekle", yeniBlog);
        }

        public IActionResult Sil(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Blog blog = _context.Blog.FirstOrDefault(x => x.ID == id);

            if (blog == null)
                return NotFound();

            return View(blog);
        }

        [HttpPost]
        public IActionResult Sil(int id, Blog sBlog)
        {
            Blog blog = _context.Blog.FirstOrDefault(x => x.ID == id);

            _context.Blog.Remove(blog);
            int sonuc = _context.SaveChanges();

            if (sonuc == 1)
            {
                return RedirectToAction(nameof(BlogController.Liste));
            }
            ViewBag.Hata = "Veri kaydetme işlemi gerçekleştirilemedi";
            return View(sBlog);
        }
    }
}
