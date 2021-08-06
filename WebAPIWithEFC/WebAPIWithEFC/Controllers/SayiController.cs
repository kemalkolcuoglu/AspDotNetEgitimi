using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIWithEFC.Context;
using WebAPIWithEFC.Models;

namespace WebAPIWithEFC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SayiController : Controller
    {
        APIContext _context;
        public SayiController(APIContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post()
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                _context.Sayilar.Add(new Models.Sayilar(random.Next(1, 1000)));
            }
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("Sum")]
        public int GetSum()
        {
            var sum = _context.Sayilar.Sum(x => x.Sayi);
            return sum;
        }

        [HttpGet]
        public IEnumerable<int> Get()
        {
            return _context.Sayilar.Select(x => x.Sayi).ToList();
        }

        [HttpGet]
        [Route("Limit/{count}")]
        public IEnumerable<int> GetWithLimit(int count)
        {
            return _context.Sayilar.Select(x => x.Sayi).Take(count).ToList();
        }

        [HttpGet]
        [Route("UcunKati")]
        public IEnumerable<int> GetUcunKati()
        {
            return _context.Sayilar.Where(x => x.Sayi % 3 == 0).Select(y => y.Sayi).ToList();
        }

        [HttpGet]
        [Route("CiftSayilar")]
        public IEnumerable<int> GetCift()
        {
            return _context.Sayilar.Where(a => a.Sayi % 2 == 0).Select(y => y.Sayi).Take(10).ToArray();
        }

        [HttpGet]
        [Route("SayiKati")]
        public IEnumerable<string> GetSayiKati()
        {
            int[] a = { 1, 2, 3, 4 };
            int[] b = { 5, 6, 7, 8 };

            //return a.Zip(a.Select(x => x * x), (first, second) => $"{first} {second}").ToArray();
            var c = _context.Sayilar.Select(x => x.Sayi * x.Sayi).ToList();

            return _context.Sayilar.AsEnumerable().Zip(c, (first, second) => $"{first.Sayi} {second}").ToList();
        }

        [HttpGet]
        [Route("GetByOrdered")]
        public IEnumerable<int> GetByOrdered()
        {
            return _context.Sayilar.OrderByDescending(x => x.Sayi).Select(x => x.Sayi).ToArray();
        }
    }
}
