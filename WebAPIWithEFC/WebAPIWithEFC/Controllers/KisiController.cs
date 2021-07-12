using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIWithEFC.Context;
using WebAPIWithEFC.Filters;
using WebAPIWithEFC.Models;

namespace WebAPIWithEFC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [HeaderEkleAttribute("Sayi", "10")]
    public class KisiController : Controller
    {
        private readonly APIContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;
        public KisiController(APIContext context, IWebHostEnvironment hostingEnvironment, IModelMetadataProvider modelMetadataProvider)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
        }

        [HttpGet]
        public IEnumerable<Kisi> Get()
        {
            IEnumerable<Kisi> kisiler = _context.Kisiler.ToList();
            return kisiler;
        }

        [HttpGet]
        [Route("{id?}")]
        public Kisi GetById(int? id)
        {
            if (id == null)
                return null;

            Kisi kisi = _context.Kisiler.FirstOrDefault(x => x.Id == id);

            return kisi;
        }

        [HttpPost]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Post([FromBody] Kisi kisi)
        {
            if(ModelState.IsValid)
            {
                _context.Kisiler.Add(kisi);
                int sonuc = _context.SaveChanges();
                return Created(kisi.Id.ToString(), kisi);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id?}")]
        public IActionResult Put(int? id, [FromBody] Kisi kisi)
        {
            if (id == null)
                return NoContent();

            Kisi _kisi = _context.Kisiler.FirstOrDefault(x => x.Id == id);

            if (_kisi == null)
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _kisi.Ad = kisi.Ad;
            _kisi.Soyad = kisi.Soyad;

            int sonuc = _context.SaveChanges();

            return Accepted(_kisi);
        }

        [HttpDelete]
        [Route("{id?}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NoContent();

            Kisi _kisi = _context.Kisiler.FirstOrDefault(x => x.Id == id);

            if (_kisi == null)
                return NotFound();

            _context.Kisiler.Remove(_kisi);
            int sonuc = _context.SaveChanges();

            return Ok(_kisi);
        }
    }
}
