using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

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
    public ActionResult <IEnumerable<Animal>> Get(string name, string gender, string species, int age, string breed, string filter, int Page, int PageLength)
    {
      var query = _db.Animals.AsQueryable();
      if (filter == "random")
      {
        Random rand = new Random();
        int newRandom = rand.Next(query.Count());
        return query.OrderBy(x => x.AnimalId).Skip(newRandom).Take(1).ToList();
      }
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
      if (filter == "less_than")
      {
        query = query.Where(entry => entry.Age <= age);
      }
      else if (filter == "greater_than")
      {
        query = query.Where(entry => entry.Age >= age);
      }
      if (breed != null)
      {
        query = query.Where(entry => entry.Breed == breed);
      }
      if (PageLength != 0)
      {
        return query.OrderBy(x => x.AnimalId).Skip((Page-1)*PageLength).Take(PageLength).ToList();
      }
      return query.ToList();
    }

    [HttpGet("{id}")]
    public Animal Get(int id)
    { 
      Animal animalToReturn = _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
      IEnumerable<AnimalVaccination> theseVaccinationLinks = _db.AnimalVaccinations.Where(entry => entry.AnimalId == id);
      foreach (AnimalVaccination link in theseVaccinationLinks)
      {
        Vaccination vaccineToAdd = _db.Vaccinations.FirstOrDefault(entry => entry.VaccinationId == link.VaccinationId);
        string name = vaccineToAdd.Name;
        animalToReturn.Add(name); 
      }
      return animalToReturn;
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