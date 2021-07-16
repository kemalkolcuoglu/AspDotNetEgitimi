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
    public class AracController : Controller
    {
        private readonly IAracService _aracService;
        public AracController(IAracService aracService)
        {
            _aracService = aracService;
        }

        [HttpGet]
        public IEnumerable<Arac> Get()
        {
            return _aracService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Arac GetById(int id)
        {
            return _aracService.GetById(id);
        }

        [HttpPost]
        public IActionResult Post(Arac arac)
        {
            int sonuc = _aracService.Add(arac);
            if (sonuc >= 1)
                return Created(arac.Id.ToString(), arac);
            else
                return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, Arac arac)
        {
            int sonuc = _aracService.Edit(id, arac);
            if(sonuc >= 1)
                return Accepted(arac);
            else
                return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            int sonuc = _aracService.Delete(id);
            if (sonuc >= 1)
                return Ok();
            else
                return BadRequest(ModelState);
        }
    }
}
