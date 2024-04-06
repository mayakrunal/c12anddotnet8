namespace Packt.Shared;

public partial class Person
{
    #region Properties: Methods to get and/or set data or state.

    // A readonly property defined using C# 1 to 5 syntax.
    public string Origin
    {
        get
        {
            return string.Format("{0} was born on {1}.", arg0: Name, arg1: HomePlanet);
        }
    }

    public string Greeting => $"{Name} says Hello!";

    public int Age => DateTime.Today.Year - Born.Year;

    // A read-write property defined using C# 3 auto-syntax.
    public string? FavoriteIceCream { get; set; }
    #endregion

    #region Indexers: Properties that use array syntax to access them.
    public Person this[int index]
    {
        get
        {
            return Children[index]; // Pass on to the List<T> indexer.
        }
        set
        {
            Children[index] = value;
        }
    }

    public Person this[string name] => Children.Find(p => p.Name == name);
    #endregion
}
