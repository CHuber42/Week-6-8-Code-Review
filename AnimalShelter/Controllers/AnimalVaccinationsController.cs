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
  public class AnimalVaccinationsController : ControllerBase
  {
    private AnimalShelterContext _db;
    public AnimalVaccinationsController(AnimalShelterContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult <IEnumerable<AnimalVaccination>> Get(int Page, int PageLength)
    {
      var query = _db.AnimalVaccinations.AsQueryable();
      if (PageLength != 0)
      {
        return query.OrderBy(x => x.AnimalVaccinationId).Skip((Page-1)*PageLength).Take(PageLength).ToList();
      }
      return query.ToList();
    }

    [HttpGet("{id}")]
    public AnimalVaccination Get(int id)
    {     
      return _db.AnimalVaccinations.FirstOrDefault(entry => entry.AnimalVaccinationId == id);
    }

    [HttpPost]
    public void Post([FromBody]AnimalVaccination animalVaccination)
    {
      _db.AnimalVaccinations.Add(animalVaccination);
      _db.SaveChanges();
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody]AnimalVaccination animalVaccination)
    {
      animalVaccination.AnimalVaccinationId = id;
      _db.Entry(animalVaccination).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      AnimalVaccination vaccineToDelete = _db.AnimalVaccinations.FirstOrDefault(entry => entry.AnimalVaccinationId == id);
      _db.AnimalVaccinations.Remove(vaccineToDelete);
      _db.SaveChanges();
    }
  }
}