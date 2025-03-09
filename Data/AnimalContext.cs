using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using System.Collections.Generic;

namespace BackEnd.Data
{
    public class AnimalContext : DbContext
    {
        public AnimalContext(DbContextOptions<AnimalContext> options)
            : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }

        public void Seed()
        {
            if (!Animals.Any())
            {
                var animals = new List<Animal>
                {
                    new Animal { Name = "perro", Translation = "dog" },
                    new Animal { Name = "gato", Translation = "cat" },
                    new Animal { Name = "elefante", Translation = "elephant" },
                    new Animal { Name = "león", Translation = "lion" },
                    new Animal { Name = "tigre", Translation = "tiger" },
                    new Animal { Name = "jirafa", Translation = "giraffe" },
                    new Animal { Name = "oso", Translation = "bear" },
                    new Animal { Name = "lobo", Translation = "wolf" },
                    new Animal { Name = "zorro", Translation = "fox" },
                    new Animal { Name = "conejo", Translation = "rabbit" },
                    new Animal { Name = "cabra", Translation = "goat" },
                    new Animal { Name = "caballo", Translation = "horse" },
                    new Animal { Name = "vaca", Translation = "cow" },
                    new Animal { Name = "cerdo", Translation = "pig" },
                    new Animal { Name = "oveja", Translation = "sheep" },
                    new Animal { Name = "ratón", Translation = "mouse" },
                    new Animal { Name = "pato", Translation = "duck" },
                    new Animal { Name = "gallina", Translation = "hen" },
                    new Animal { Name = "pollo", Translation = "chicken" },
                    new Animal { Name = "águila", Translation = "eagle" },
                    new Animal { Name = "pájaro", Translation = "bird" },
                    new Animal { Name = "pingüino", Translation = "penguin" },
                    new Animal { Name = "delfín", Translation = "dolphin" },
                    new Animal { Name = "tiburón", Translation = "shark" },
                    new Animal { Name = "ballena", Translation = "whale" }
                };

                Animals.AddRange(animals);
                SaveChanges();
            }
        }
    }
}
