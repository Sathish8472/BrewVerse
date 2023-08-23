using BarService.Models;
using BarService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarService.Controllers
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
        public async Task<ActionResult<IEnumerable<Bar>>> GetAllBars()
        {
            var bars = await _barService.GetAllBarsAsync();
            return Ok(bars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bar>> GetBarById(int id)
        {
            var bar = await _barService.GetBarByIdAsync(id);
            if (bar == null)
                return NotFound();

            return Ok(bar);
        }

        [HttpPost]
        public async Task<ActionResult<Bar>> CreateBar(Bar bar)
        {
            var createdBar = await _barService.CreateBarAsync(bar);
            return CreatedAtAction(nameof(GetBarById), new { id = createdBar.Id }, createdBar);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Bar>> UpdateBar(int id, Bar bar)
        {
            var updatedBar = await _barService.UpdateBarAsync(id, bar);
            if (updatedBar == null)
                return NotFound();

            return Ok(updatedBar);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBar(int id)
        {
            var result = await _barService.DeleteBarAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
