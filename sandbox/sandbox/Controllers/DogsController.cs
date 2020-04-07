using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sandbox.Data;
using sandbox.Models;
using sandbox.Models.Interfaces;
using sandbox.Models.Services;

namespace sandbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        /// <summary>
        ///  change it interface
        /// </summary>
        private readonly IDoggys _doggy;

        // TODO DI: use the dogys
        public DogsController(IDoggys context)
        {
            _doggy = context;
        }

        // GET: api/Dogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dogs>>> GetDogs()
        {
            //get method of the dogs

            return await _doggy.GetDogs();
        }

        // GET: api/Dogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dogs>> GetDogs(int id)
        {
            //change this to await with id
           return await _doggy.GetDog(id);
        }

        // PUT: api/Dogs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<Dogs> PutDogs(int id, Dogs dogs)
        {
            return await _doggy.UpdateDog(id, dogs);
           
        }

        // POST: api/Dogs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Dogs>> PostDogs(Dogs dogs)
        {
            await _doggy.CreateAnimal(dogs);

            return CreatedAtAction("GetDogs", new { id = dogs.ID }, dogs);
        }

        // DELETE: api/Dogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dogs>> DeleteDogs(int id)
        {
            return await _doggy.DeleteDog(id);
        }


    }
}
