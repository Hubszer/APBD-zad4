using APBDzad4.DataBase;
using APBDzad4.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBDzad4.Controllers;


[ApiController]
[Route("/animals-controller")]
//[Route("[Controller]")]
public class AnimalController : ControllerBase
{

  public AnimalController()
  {
    
  }

[HttpGet]
  public IActionResult GetAnimals()
  {
    var animals = new MockDB().Animals;
    return Ok(animals);
  }  
  [HttpPost]
  public IActionResult AddAnimal()
  {
    return Created();
  }

  [HttpPut]
  public IActionResult UpdateAnimal(int id, Animal animal)
  {
    var existingAnimal = StaticData.Animals.FirstOrDefault(a => a.Id == id);
    
    if (existingAnimal == null)
    {
      return NotFound();
    }

    existingAnimal.NameType = animal.NameType;
    existingAnimal.Category = animal.Category;
    existingAnimal.Mass = animal.Mass;
    existingAnimal.FurColor = animal.FurColor;
    return NoContent();
  }
  
  
  [HttpDelete]
  public IActionResult DeleteAnimal(int Id)
  {
    var animal = StaticData.Animals.FirstOrDefault(a => a.Id == Id);

    if (animal == null)
    {
      return NotFound();
    }

    StaticData.Animals.Remove(animal);
    return NoContent();
  }
}