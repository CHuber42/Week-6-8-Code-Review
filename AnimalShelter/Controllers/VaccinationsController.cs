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
  public class VaccinationsController : ControllerBase
  {
    private AnimalShelterContext _db;
    public VaccinationsController(AnimalShelterContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult <IEnumerable<Vaccination>> Get(string name, int Page, int PageLength)
    {
      var query = _db.Vaccinations.AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      if (PageLength != 0)
      {
        return query.OrderBy(x => x.VaccinationId).Skip((Page-1)*PageLength).Take(PageLength).ToList();
      }
      return query.ToList();
    }

    [HttpGet("{id}")]
    public Vaccination Get(int id)
    {     
      return _db.Vaccinations.FirstOrDefault(entry => entry.VaccinationId == id);
    }

    [HttpPost]
    public void Post([FromBody]Vaccination vaccination)
    {
      _db.Vaccinations.Add(vaccination);
      _db.SaveChanges();
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody]Vaccination vaccination)
    {
      vaccination.VaccinationId = id;
      _db.Entry(vaccination).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      Vaccination vaccineToDelete = _db.Vaccinations.FirstOrDefault(entry => entry.VaccinationId == id);
      _db.Vaccinations.Remove(vaccineToDelete);
      _db.SaveChanges();
    }
  }
}