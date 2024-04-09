using APBDzad4.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace APBDzad4.Controllers;


[ApiController]
[Route("/animals-controller")]
//[Route("[Controller]")]
public class AnimalController : ControllerBase
{
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
}