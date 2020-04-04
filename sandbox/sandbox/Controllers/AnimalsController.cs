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
    public class AnimalsController : ControllerBase
    {
        private readonly AnimalShelterDbContext _context;

        public AnimalsController(AnimalShelterDbContext context)
        {
            _context = context;
        }

        // GET: api/Animals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animals>>> GetAnimals()
        {
            return await _context.Animals.ToListAsync();
        }

        // GET: api/Animals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animals>> GetAnimals(int id)
        {
            var animals = await _context.Animals.FindAsync(id);

            if (animals == null)
            {
                return NotFound();
            }

            return animals;
        }

        // PUT: api/Animals/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimals(int id, Animals animals)
        {
            if (id != animals.DogsID)
            {
                return BadRequest();
            }

            _context.Entry(animals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalsExists(id))
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

        // POST: api/Animals
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Animals>> PostAnimals(Animals animals)
        {
            _context.Animals.Add(animals);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AnimalsExists(animals.DogsID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAnimals", new { id = animals.DogsID }, animals);
        }

        // DELETE: api/Animals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Animals>> DeleteAnimals(int id)
        {
            var animals = await _context.Animals.FindAsync(id);
            if (animals == null)
            {
                return NotFound();
            }

            _context.Animals.Remove(animals);
            await _context.SaveChangesAsync();

            return animals;
        }

        private bool AnimalsExists(int id)
        {
            return _context.Animals.Any(e => e.DogsID == id);
        }
    }
}
