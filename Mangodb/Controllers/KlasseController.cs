using System;
using Microsoft.AspNetCore.Mvc;
using MongoExample.Services;
using MongoExample.Models;

namespace MangoExample.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class KlasseController : Controller
    {
        private readonly MongoDBService _mongoDBService;

        public KlasseController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [HttpGet]
        public async Task<List<Bestellungen>> Get() 
        { 
            return await _mongoDBService.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bestellungen>> GetById(string id)
        {
            var bestellung = await _mongoDBService.GetAsyncId(id);
            if (bestellung == null)
            {
                return NotFound();
            }
            return bestellung;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Bestellungen bestellungen) { 
            await _mongoDBService.CreateAsync(bestellungen);
            return CreatedAtAction(nameof(Get),new { id = bestellungen.Id }, bestellungen);
        }
        //noch anpassen

        [HttpPut("{id}")]
        public async Task<IActionResult> AddToKlasse(string id, [FromBody] string Klassenlehrer) 
        {
            await _mongoDBService.AddToKlasseAsync(id, Klassenlehrer);
            return NoContent();
        }
        //noch anpassen

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id) 
        {
            await _mongoDBService.DeteleAsync(id);
            return NoContent();
        }
        // noch anpassen
    }
}
