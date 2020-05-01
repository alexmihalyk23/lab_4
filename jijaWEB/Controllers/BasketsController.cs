using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jijaWEB.Data;

namespace jijaWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly jijaWEBContext _context;

        public BasketsController(jijaWEBContext context)
        {
            _context = context;
        }

        // GET: api/Baskets
        [HttpGet]
        public IEnumerable<Basket> GetBasket()
        {
            return _context.Basket;
        }

        // GET: api/Baskets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasket([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var basket = await _context.Basket.FindAsync(id);

            if (basket == null)
            {
                return NotFound();
            }

            return Ok(basket);
        }

        // PUT: api/Baskets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasket([FromRoute] int id, [FromBody] Basket basket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != basket.id)
            {
                return BadRequest();
            }

            _context.Entry(basket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BasketExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Baskets
        [HttpPost]
        public async Task<IActionResult> PostBasket([FromBody] Basket basket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Basket.Add(basket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBasket", new { id = basket.id }, basket);
        }

        // DELETE: api/Baskets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasket([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var basket = await _context.Basket.FindAsync(id);
            if (basket == null)
            {
                return NotFound();
            }

            _context.Basket.Remove(basket);
            await _context.SaveChangesAsync();

            return Ok(basket);
        }

        private bool BasketExists(int id)
        {
            return _context.Basket.Any(e => e.id == id);
        }
    }
}