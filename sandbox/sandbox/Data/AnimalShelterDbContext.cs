using Microsoft.EntityFrameworkCore;
using sandbox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sandbox.Data
{
    // TODO 3: create a DATA folder with name `DbContext`. Add `: DbContext`.
    public class AnimalShelterDbContext : DbContext
    {
        // TODO: do this
        public AnimalShelterDbContext(DbContextOptions<AnimalShelterDbContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animals>().HasKey(e => new { e.DogsID, e.CatsID });

            modelBuilder.Entity<Shelter>().HasKey(e => new { e.DogsID, e.CatsID });


            // TODO: add this to seed
            modelBuilder.Entity<Dogs>().HasData(
                new Dogs
                {
                    ID = 1,
                    Name = "Mochi",
                    Age = 1,
                    Gender = "Male",
                    Type = "GoldenPoodle"
                },
                new Dogs
                {
                    ID = 2,
                    Name = "Kudo",
                    Age = 16,
                    Gender = "Male",
                    Type = "Morkie"
                },
                new Dogs
                {
                    ID = 3,
                    Name = "Gochi",
                    Age = 1,
                    Gender = "Male",
                    Type = "MochiPochi"
                }
                );

            modelBuilder.Entity<Cats>().HasData(
                new Cats
                {
                    ID = 1,
                    Name = "Garfield",
                    Age = 100,
                    Gender = "Male",
                    Type = "Fat cat"
                },
                new Cats
                {
                    ID = 2,
                    Name = "Josie",
                    Age = 20,
                    Gender = "Female",
                    Type = "Fat Cat"
                },
                new Cats
                {
                    ID = 3,
                    Name = "Rochi",
                    Age = 1,
                    Gender = "Male",
                    Type = "MochiPochi"
                }
                );
            modelBuilder.Entity<Shelter>().HasData(
                new Shelter
                {
                    CatsID = 1,
                    DogsID = 1,
                    type = (int)0
                }
                );
        }

        // TODO: add this
        public DbSet<Animals> Animals { get; set; }
        public DbSet<Cats> Cats { get; set; }
        public DbSet<Dogs> Dogs { get; set; }
        public DbSet<Shelter> Shelter { get; set; }
    }


}
