namespace SelectionStatements;

public class Animal
{
    public string? Name;
    public DateTime Born;

    public byte Legs;
}

public class Cat : Animal
{
    public bool IsDomestic;
}

public class Spider : Animal // This is another subtype of animal.
{
    public bool IsPoisonous;
}