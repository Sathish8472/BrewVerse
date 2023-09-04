using BrewVerse.Abstractions.Dto;
using BrewVerse.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BrewVerse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService _beerService;

        public BeerController(IBeerService beerService)
        {
            _beerService = beerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBeers()
        {
            var response = await _beerService.GetAllBeersAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetBeerById(int id)
        {
            var response = await _beerService.GetBeerByIdAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BeerDto>> CreateBeer(BeerDto beerDto)
        {
            var response = await _beerService.CreateBeerAsync(beerDto);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BeerDto>> UpdateBeer(int id, BeerDto beerDto)
        {
            var response = await _beerService.UpdateBeerAsync(id, beerDto);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBeer(int id)
        {
            var response = await _beerService.DeleteBeerAsync(id);
            return Ok(response);
        }
    }
}
