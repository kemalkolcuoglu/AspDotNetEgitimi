using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIGiris.Models;

namespace WebAPIGiris.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KisiController : ControllerBase
    {
        WebAPIContext _context;
        public KisiController(WebAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Kisi> kisiler =_context.Kisi.ToList();
            return Ok(kisiler);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int? id)
        {
            Kisi kisi = _context.Kisi.FirstOrDefault(x => x.ID == id);
            return Ok(kisi);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Kisi kisi)
        {
            if (ModelState.IsValid)
            {
                _context.Kisi.Add(kisi);
                _context.SaveChanges();
                return Created("GetByID", new { id = kisi.ID });
            }
            return BadRequest(kisi);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int? id, [FromBody] Kisi kisi)
        {
            if (ModelState.IsValid)
            {
                Kisi _kisi = _context.Kisi.FirstOrDefault(x => x.ID == id);
                _kisi.Ad = kisi.Ad;
                _kisi.Soyad = kisi.Soyad;
                _kisi.Yas = kisi.Yas;
                _context.SaveChanges();
                return Ok(kisi);
            }
            return BadRequest(kisi);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            Kisi kisi = _context.Kisi.FirstOrDefault(x => x.ID == id);
            _context.Kisi.Remove(kisi);
            _context.SaveChanges();
            return Accepted(kisi);
        }
    }
}
