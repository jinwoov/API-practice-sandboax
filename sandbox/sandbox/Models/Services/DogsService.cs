using Microsoft.EntityFrameworkCore;
using sandbox.Data;
using sandbox.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sandbox.Models.Services
{
    // add services folder and implement the interfaces
    public class DogsService : IDoggys
    {
        private AnimalShelterDbContext _context;
        public DogsService(AnimalShelterDbContext context)
        {
            _context = context;
        }
        /// change the return to the task
        /// You must return and  task for it to work
        public async Task CreateAnimal(Dogs dog)
        {
            // add item
            _context.Dogs.Add(dog);

            // save the data make it the asynchronous
             await _context.SaveChangesAsync();
        }

        public async Task<Dogs> DeleteDog(int id)
        {
            var dog = await _context.Dogs.FindAsync(id);

            _context.Remove(dog);

            await _context.SaveChangesAsync();

            return dog;
        }

        // change this by using the task as a return type. return the student
        // Return will have variable of dog which will be object
        public async Task<Dogs> GetDog(int id)
        {
           var dog =  await  _context.Dogs.FindAsync(id);
            return dog;
        }

        public async Task<List<Dogs>> GetDogs()
        {
           return await _context.Dogs.ToListAsync();
        }

        public async Task UpdateDog(Dogs dog)
        {
            _context.Update(dog);

            await _context.SaveChangesAsync();

        }

    }
}
