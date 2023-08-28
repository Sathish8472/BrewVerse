using BeerService.API.Models;
using BeerService.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService _beerService;

        public BeerController(IBeerService beerService)
        {
            _beerService = beerService;
        }

        [HttpPost]
        public async Task<IActionResult> PostBeer(Beer beer)
        {
            try
            {
                var createdBeer = await _beerService.CreateBeerAsync(beer);
                return CreatedAtAction(nameof(GetBeerById), new { id = createdBeer.Id }, createdBeer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetBeers()
        {
            try
            {
                var beers = await _beerService.GetAllBeersAsync();
                return Ok(beers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBeerById(int id)
        {
            try
            {
                var beer = await _beerService.GetBeerByIdAsync(id);
                if (beer == null)
                {
                    return NotFound();
                }
                return Ok(beer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBeer(int id, Beer beer)
        {
            try
            {
                var existingBeer = await _beerService.GetBeerByIdAsync(id);
                if (existingBeer == null)
                {
                    return NotFound();
                }

                existingBeer.Name = beer.Name;
                existingBeer.PercentageAlcoholByVolume = beer.PercentageAlcoholByVolume;

                await _beerService.UpdateBeerAsync(existingBeer);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeer(int id)
        {
            try
            {
                var existingBeer = await _beerService.GetBeerByIdAsync(id);
                if (existingBeer == null)
                {
                    return NotFound();
                }

                await _beerService.DeleteBeerAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
