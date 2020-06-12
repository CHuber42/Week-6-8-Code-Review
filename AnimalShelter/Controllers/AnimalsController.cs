using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private AnimalShelterContext _db;
    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult <IEnumerable<Animal>> Get(string name, string gender, string species, int age, string breed)
    {
      var query = _db.Animals.AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      if (gender != null)
      {
        query = query.Where(entry => entry.Gender == gender);
      }
      if (species != null)
      {
        query = query.Where(entry => entry.Species == species);
      }
      if (age != null && age > 0)
      {
        query = query.Where(entry => entry.Age == age);
      }
      if (breed != null)
      {
        query = query.Where(entry => entry.Breed == breed);
      }
      return query.ToList();
    }

    [HttpGet("{id}")]
    public Animal Get(int id)
    {     
      return _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
    }

    [HttpPost]
    public void Post([FromBody]Animal animal)
    {
      _db.Animals.Add(animal);
      _db.SaveChanges();
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody]Animal animal)
    {
      animal.AnimalId = id;
      _db.Entry(animal).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      Animal animalToDelete = _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
      _db.Animals.Remove(animalToDelete);
      _db.SaveChanges();
    }
  }
}