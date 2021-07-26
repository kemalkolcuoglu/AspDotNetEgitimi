using Microsoft.AspNetCore.Mvc;
using SimpleRentACarProject.Business.Abstract;
using SimpleRentACarProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRentACarProject.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusteriController : Controller
    {
        private readonly IMusteriService _musteriService;

        public MusteriController(IMusteriService musteriService)
        {
            _musteriService = musteriService;
        }

        [HttpGet]
        public IEnumerable<Musteri> Get()
        {
            return _musteriService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Musteri GetById(int id)
        {
            return _musteriService.GetById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Musteri musteri)
        {
            int result = _musteriService.Add(musteri);
            if (result > 0)
                return Created(musteri.Id.ToString(), musteri);
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("{id?}")]
        public IActionResult Put(int? id, [FromBody] Musteri musteri)
        {
            if (id == null)
                return BadRequest();

            Musteri _musteri = _musteriService.GetById(id.Value);

            if (_musteri == null)
                return NotFound();

            int result = _musteriService.Edit(id.Value, musteri);

            if (result > 0)
                return Accepted(_musteri.Id.ToString(), musteri);
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{id?}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            int result = _musteriService.Delete(id.Value);

            if (result > 0)
                return Ok();
            return BadRequest(ModelState);
        }
    }
}
