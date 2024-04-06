using SelectionStatements;

#region Pattern Matching 

object o = 3;
int j = 4;

if (o is int i)
{
    WriteLine($"{i} x {j} = {i * j}");
}
else
{
    WriteLine("o is not an int so it cannot multiply!");
}

#endregion

#region Switch Branching
// Inclusive lower bound but exclusive upper bound.
int number = Random.Shared.Next(minValue: 1, maxValue: 7);
WriteLine($"My random number is {number}");
switch (number)
{
    case 1:
        WriteLine("One");
        break; // Jumps to end of switch statement.
    case 2:
        WriteLine("Two");
        goto case 1;
    case 3: // Multiple case section.
    case 4:
        WriteLine("Three or four");
        goto case 1;
    case 5:
        goto A_label;
    default:
        WriteLine("Default");
        break;
} // End of switch statement.
WriteLine("After end of switch");
A_label:
WriteLine($"After A_label");


var animals = new Animal?[]{
    new Cat{ Name="Karen",Born= new(2022,8,23),Legs=4,IsDomestic=true},
    null,
    new Cat { Name = "Mufasa", Born = new(year: 1994, month: 6,day: 12) },
    new Spider { Name = "Sid Vicious", Born = DateTime.Today, IsPoisonous = true},
    new Spider { Name = "Captain Furry", Born = DateTime.Today }
};

foreach (Animal? animal in animals)
{
    string message = animal switch
    {
        Cat fourCat when fourCat.Legs == 4 => $"The cat named {fourCat.Name} has four legs.",
        Cat wildCat when wildCat.IsDomestic == false => $"The non-domestic cat is named {wildCat.Name}.",
        Cat cat => $"The cat is named {cat.Name}.",
        Spider spider when spider.IsPoisonous => $"The {spider.Name} spider is poisonous. Run!",
        null => "The animal is null.",
        _ => $"{animal.Name} is a {animal.GetType().Name}.",
    };
    WriteLine($"switch statement: {message}");
}

#endregion

#region while loop
int x = 0;
while (x < 10)
{
    WriteLine(x);
    x++;
}

// string? actualPassword = "Pa$$w0rd";
// string? password;
// do
// {
//     Write("Enter your password: ");
//     password = ReadLine();
// }
// while (password != actualPassword);

// WriteLine("Correct!");

#endregion

#region Loops
for (int y = 1; y <= 10; y++)
{
    WriteLine(y);
}

for (int y = 0; y <= 10; y += 3)
{
    WriteLine(y);
}

string[] names = { "Adam", "Barry", "Charlie" };

foreach (string name in names)
{
    WriteLine($"{name} has {name.Length} characters.");
}
#endregion