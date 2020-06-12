using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace AnimalShelter.Controllers
{
  public class AnimalsController : BaseController
  {
    private AnimalShelterContext _db;
    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult <IEnumerable<Animal>> Get(string name, string gender, string species, int age, string breed)
    {
      
    }

    [HttpGet("{id}")]
    public Animal Get(int id)
    {

    }

    [HttpPost]
    public ActionResult Post([FromBody]Animal animal)
    {

    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody]Animal animal)
    {

    }

    [HttpPost]
    public void Delete(int id)
    {
      
    }

  }
}