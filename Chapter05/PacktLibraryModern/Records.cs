namespace Packt.Shared;

public class ImmutablePerson
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
}

public record ImmutableVehicle
{
    public int Wheels { get; init; }
    public string? Color { get; init; }
    public string? Brand { get; init; }

}

public class AnimalClass
{
    public string? Name { get; set; }
}
public record AnimalRecord
{
    public string? Name { get; set; }
}

/* 
public record ImmutableAnimal
{
    public string Name { get; init; }
    public string Species { get; init; }

    public ImmutableAnimal(string name, string species)
    {
        Name = name;
        Species = species;
    }

    public void Deconstruct(out string name, out string species)
    {
        name = Name;
        species = Species;
    }
}
 */

// Simpler syntax to define a record that auto-generates the
// properties, constructor, and deconstructor.
public record ImmutableAnimal(string Name, string Species);

