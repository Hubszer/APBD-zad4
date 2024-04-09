using APBDzad4.DataBase;
using APBDzad4.Models;

namespace APBDzad4.EndPoints;

public static class AnimalEndPoints
{
    public static void MapAnimalEndpoints(this WebApplication app)
    {
        app.MapGet("/animals/", () =>
        {
            var animals = StaticData.Animals;
            
            return Results.Ok();
        });

        app.MapGet("/animals/{id}", (int id) =>
        {
            //200 - Ok
            //400 - Bad Request
            //401 = Unautohized
            //403 - Forbidden
            //404 - Not found 
            //500 - Internal Server Error

            return Results.Ok(id);
        });

        app.MapPost("/animals", (Animal animal) =>
        {
            //201 - Created
            return Results.Created("", animal);

        });

    }
}