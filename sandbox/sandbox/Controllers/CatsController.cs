﻿using System;
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
    public class CatsController : ControllerBase
    {
        private readonly AnimalShelterDbContext _context;

        public CatsController(AnimalShelterDbContext context)
        {
            _context = context;
        }

        // GET: api/Cats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cats>>> GetCats()
        {
            return await _context.Cats.ToListAsync();
        }

        // GET: api/Cats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cats>> GetCats(int id)
        {
            var cats = await _context.Cats.FindAsync(id);

            if (cats == null)
            {
                return NotFound();
            }

            return cats;
        }

        // PUT: api/Cats/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCats(int id, Cats cats)
        {
            if (id != cats.ID)
            {
                return BadRequest();
            }

            _context.Entry(cats).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatsExists(id))
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

        // POST: api/Cats
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Cats>> PostCats(Cats cats)
        {
            _context.Cats.Add(cats);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCats", new { id = cats.ID }, cats);
        }

        // DELETE: api/Cats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cats>> DeleteCats(int id)
        {
            var cats = await _context.Cats.FindAsync(id);
            if (cats == null)
            {
                return NotFound();
            }

            _context.Cats.Remove(cats);
            await _context.SaveChangesAsync();

            return cats;
        }

        private bool CatsExists(int id)
        {
            return _context.Cats.Any(e => e.ID == id);
        }
    }
}
