using APBDzad4.Models;

namespace APBDzad4.DataBase;

public class StaticData
{
    public static List<Animal> Animals = new List<Animal>()
    {
        new Animal(),
        new Animal(),
        new Animal(),
    };

    public static List<Visit> Visits = new List<Visit>()
    {
        new Visit(),
        new Visit(),
        new Visit(),
    };
}