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
  
  [HttpGet]
  public IActionResult GetAnimals()
  {
    var animals = StaticData.Animals;
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

    StaticData.Animals.Remove(existingAnimal);
    StaticData.Animals.Add(animal);
    return Ok($"Updated anima ID={animal.Id}");
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
    return Ok($"Deleted the animal with ID={animal.Id}");
  }
}