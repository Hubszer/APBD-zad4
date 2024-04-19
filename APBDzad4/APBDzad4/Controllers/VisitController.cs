using APBDzad4.DataBase;
using APBDzad4.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBDzad4.Controllers;

[ApiController]
[Route("/visits-controller")]
public class VisitController : ControllerBase
{
    [HttpGet]
    public IActionResult GetVisitsByAnimal(int id)
    {
        var visit = StaticData.Visits.Where(v => v.AnimalId == id).ToList();
        if (visit.Count == 0)
        {
            return NotFound();
        }
        return Ok(visit);
    }

    [HttpPost]
    public IActionResult AddVisit(Visit visit)
    {
        if (visit == null)
        {
            return NotFound();
        }

        var animalExists = StaticData.Animals.Any(a => a.Id == visit.AnimalId);
        if (!animalExists)
        {
            return NotFound();
        }
        
        visit.Id = StaticData.Visits.Count + 1;
        StaticData.Visits.Add(visit);
        return CreatedAtAction(nameof(GetVisitsByAnimal), new { animalId = visit.AnimalId }, visit);
    }
}