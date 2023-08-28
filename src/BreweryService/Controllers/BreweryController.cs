using Microsoft.AspNetCore.Mvc;
using BreweryService.API.Models;
using BreweryService.API.Services;

namespace BreweryService.API.Controllers
{
    [ApiController]
    [Route("brewery")]
    public class BreweryController : ControllerBase
    {
        private readonly IBreweryService _breweryService;

        public BreweryController(IBreweryService breweryService)
        {
            _breweryService = breweryService;
        }

        [HttpPost]
        public IActionResult AddBrewery(Brewery brewery)
        {
            var newBrewery = _breweryService.AddBrewery(brewery);
            return CreatedAtAction(nameof(GetBreweryById), new { id = newBrewery.Id }, newBrewery);
        }

        [HttpGet("{id}")]
        public IActionResult GetBreweryById(int id)
        {
            var brewery = _breweryService.GetBreweryById(id);
            if (brewery == null)
            {
                return NotFound();
            }
            return Ok(brewery);
        }

        [HttpGet]
        public IActionResult GetAllBreweries()
        {
            var breweries = _breweryService.GetAllBreweries();
            return Ok(breweries);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBrewery(int id, Brewery brewery)
        {
            if (id != brewery.Id)
            {
                return BadRequest();
            }

            var updatedBrewery = _breweryService.UpdateBrewery(brewery);
            if (updatedBrewery == null)
            {
                return NotFound();
            }

            return Ok(updatedBrewery);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBrewery(int id)
        {
            var deletedBrewery = _breweryService.DeleteBrewery(id);
            if (deletedBrewery == null)
            {
                return NotFound();
            }

            return Ok(deletedBrewery);
        }
    }
}
