using APBDzad4.DataBase;
using APBDzad4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

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

  

  [HttpGet("{id}")]
  public IActionResult GetAnimal(int id)
  {
    var animal = StaticData.Animals.FirstOrDefault(a => a.Id == id);
    if (animal == null)
    {
      return NotFound();
    }
    return Ok(animal);
  }
  [HttpPost] 
  public IActionResult AddAnimal(Animal animal)
  {
    if (animal == null)
    {
      return NotFound();
    }

    animal.Id = StaticData.Animals.Max(a => a.Id) + 1;
    StaticData.Animals.Add(animal);
    return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
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
  public IActionResult DeleteAnimal(int id)
  {
    var animal = StaticData.Animals.FirstOrDefault(a => a.Id == id);

    if (animal == null)
    {
      return NotFound();
    }

    StaticData.Animals.Remove(animal);
    return NoContent();
  }
}