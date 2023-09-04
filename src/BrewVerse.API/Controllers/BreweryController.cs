using BrewVerse.Abstractions.Dto;
using BrewVerse.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BrewVerse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweryController : ControllerBase
    {
        private readonly IBreweryService _breweryService;

        public BreweryController(IBreweryService breweryService)
        {
            _breweryService = breweryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBreweries()
        {
            var response = await _breweryService.GetAllBreweriesAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BreweryDto>> GetBreweryById(int id)
        {
            var response = await _breweryService.GetBreweryByIdAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BreweryDto>> CreateBrewery(BreweryDto breweryDto)
        {
            var response = await _breweryService.CreateBreweryAsync(breweryDto);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BreweryDto>> UpdateBrewery(int id, BreweryDto breweryDto)
        {
            var response = await _breweryService.UpdateBreweryAsync(id, breweryDto);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBrewery(int id)
        {
            var response = await _breweryService.DeleteBreweryAsync(id);
            return Ok(response);
        }
    }
}
