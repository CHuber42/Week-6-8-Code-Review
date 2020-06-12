using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalShelter.Models
{
  public class Animal
  {
    public int AnimalId {get; set;}
    public string Name {get; set;}

    public string Species {get; set;}
    public string Gender {get; set;}

    public string Breed {get; set;}

    public int Age {get; set;}
    [NotMapped]
    public List<string> Vaccinations;

    public void Add(string name)
    {
      Vaccinations = new List<string>();
      Vaccinations.Add(name);
    }
  }
}