using BrewVerse.Abstractions.Dto;
using BrewVerse.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrewVerse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarController : ControllerBase
    {
        private readonly IBarService _barService;

        public BarController(IBarService barService)
        {
            _barService = barService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBars()
        {
            var response = await _barService.GetAllBarsAsync();
            return Ok(Response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BarDto>> GetBarById(int id)
        {
            var response = await _barService.GetBarByIdAsync(id);
           
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BarDto>> CreateBar(BarDto barDto)
        {
            var response = await _barService.CreateBarAsync(barDto);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BarDto>> UpdateBar(int id, BarDto barDto)
        {
            var response = await _barService.UpdateBarAsync(id, barDto);
            return Ok(response);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBar(int id)
        {
            var response = await _barService.DeleteBarAsync(id);

            return Ok(response);
        }
    }
}
