using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sandbox.Data;
using sandbox.Models;

namespace sandbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private readonly AnimalShelterDbContext _context;

        public DogsController(AnimalShelterDbContext context)
        {
            _context = context;
        }

        // GET: api/Dogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dogs>>> GetDogs()
        {
            return await _context.Dogs.ToListAsync();
        }

        // GET: api/Dogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dogs>> GetDogs(int id)
        {
            var dogs = await _context.Dogs.FindAsync(id);

            if (dogs == null)
            {
                return NotFound();
            }

            return dogs;
        }

        // PUT: api/Dogs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDogs(int id, Dogs dogs)
        {
            if (id != dogs.ID)
            {
                return BadRequest();
            }

            _context.Entry(dogs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogsExists(id))
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

        // POST: api/Dogs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Dogs>> PostDogs(Dogs dogs)
        {
            _context.Dogs.Add(dogs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDogs", new { id = dogs.ID }, dogs);
        }

        // DELETE: api/Dogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dogs>> DeleteDogs(int id)
        {
            var dogs = await _context.Dogs.FindAsync(id);
            if (dogs == null)
            {
                return NotFound();
            }

            _context.Dogs.Remove(dogs);
            await _context.SaveChangesAsync();

            return dogs;
        }

        private bool DogsExists(int id)
        {
            return _context.Dogs.Any(e => e.ID == id);
        }
    }
}
