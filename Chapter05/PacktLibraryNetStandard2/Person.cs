namespace Packt.Shared;

public partial class Person
{

    #region Fields: Data or state for this person.
    public string? Name;
    public DateTimeOffset Born;

    public WondersOfTheAncientWorld BucketList;

    public List<Person> Children = [];

    public const string Species = "Homo Sapiens";

    // Read-only fields: Values that can be set at runtime.
    public readonly string HomePlanet = "Earth";

    public readonly DateTime Instantiated;

    #endregion

    #region Constructors
    public Person()
    {
        // Constructors can set default values for fields
        // including any read-only fields like Instantiated.
        Name = "Unknown";
        Instantiated = DateTime.Now;
    }
    public Person(string initialName, string homePlanet)
    {
        Name = initialName;
        HomePlanet = homePlanet;
        Instantiated = DateTime.Now;
    }
    #endregion

    #region Methods: Actions the type can perform.

    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {Born:dddd}.");
    }

    public string GetOrigin()
    {
        return $"{Name} was on Born on {HomePlanet}";
    }
    public string SayHello()
    {
        return $"{Name} says 'Hello!'";
    }
    public string SayHello(string name)
    {
        return $"{Name} says 'Hello, {name}!'";
    }

    public string OptionalParameters(string command = "Run!", double number = 0.0, bool active = true)
    {
        return string.Format(
         "command is {0}, number is {1}, active is {2}", command, number, active);
    }

    public void PassingParameters(int w, in int x, ref int y, out int z)
    {
        // out parameters cannot have a default and they
        // must be initialized inside the method.
        z = 100;
        // Increment each parameter except the read-only x.
        w++;
        // x++; // Gives a compiler error!
        y++;
        z++;
        WriteLine($"In the method: w={w}, x={x}, y={y}, z={z}");
    }

    public (string Name, int Number) GetFruit()
    {
        return ("Apples", 5);
    }

    public void Deconstruct(out string? name, out DateTimeOffset dob)
    {
        name = Name;
        dob = Born;
    }

    public void Deconstruct(out string? name, out DateTimeOffset dob, out WondersOfTheAncientWorld fav)
    {
        name = Name;
        dob = Born;
        fav = BucketList;
    }

    // Method with a local function.
    public static int Factorial(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException(
            $"{nameof(number)} cannot be less than zero.");
        }
        return localFactorial(number);
        int localFactorial(int localNumber) // Local function.
        {
            if (localNumber == 0) return 1;
            return localNumber * localFactorial(localNumber - 1);
        }
    }
    #endregion
}