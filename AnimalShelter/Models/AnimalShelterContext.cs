using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext : DbContext
  {
    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
        : base(options)
    {
    }

    public DbSet<AnimalVaccination> AnimalVaccinations {get; set;}
    public DbSet<Vaccination> Vaccinations {get;set;}
    public DbSet<Animal> Animals {get; set;}
  }
}