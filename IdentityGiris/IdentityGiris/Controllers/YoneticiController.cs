using IdentityGiris.Data;
using IdentityGiris.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityGiris.Controllers
{
    [Authorize(Roles = "Admin")]
    public class YoneticiController : Controller
    {
        ApplicationDbContext _applicationDbContext;
        UserManager<IdentityUser> _userManager;
        RoleManager<IdentityRole> _roleManager;

        public YoneticiController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _applicationDbContext = context;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            List<IdentityUser> users = _userManager.Users.ToList();
            return View(users);
        }

        public IActionResult Deneme()
        {
            return View();
        }

        public IActionResult RoleIndex()
        {
            List<IdentityRole> roller = _roleManager.Roles.ToList();

            return View();
        }

        public IActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UyeEkle(Kullanici kullanici)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var sonuc = await _userManager.CreateAsync(kullanici);
                    await _userManager.AddToRolesAsync(kullanici, new List<string>() { "Admin", "User" });
                    if (sonuc.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                ViewBag.Hata = "Hata meydana geldi!";
            }
            catch (Exception exp)
            {
                ViewBag.Hata = exp.Message;
            }
            return View(kullanici);
        }

        public IActionResult RolEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RolEkle(Rol rol)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var sonuc = await _roleManager.CreateAsync(rol);
                    if(sonuc.Succeeded)
                    {
                        return RedirectToAction(nameof(RoleIndex));
                    }
                }
            }
            catch (Exception)
            {

            }
            return View(rol);
        }
    }
}
