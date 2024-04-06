using Packt.Shared;

ConfigureConsole(); // Sets current culture to US English.

Person bob = new()
{
    Name = "Bob Smith",

    Born = new(1965, 12, 22, 16, 28, 0, TimeSpan.FromHours(-5)),

    BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon | WondersOfTheAncientWorld.MausoleumAtHalicarnassus
};

bob.Children.Add(new() { Name = "Alfred" });
bob.Children.Add(new() { Name = "Zoe" });
bob.Children.Add(new() { Name = "Bella" });

WriteLine(format: "{0} was born on {1:D}.", bob.Name, bob.Born); // Long date.

WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}.");

WriteLine($"{bob.Name} has {bob.Children.Count} children:");

for (int i = 0; i < bob.Children.Count; i++)
{
    WriteLine($"> {bob.Children[i].Name}");
}

BankAccount.InterestRate = 0.012M; // Store a shared value in static field.

BankAccount jonesAccount = new()
{
    AccountName = "Mrs. Jones",
    Balance = 2400
};

BankAccount gerrierAccount = new()
{
    AccountName = "Ms. Gerrier",
    Balance = 98
};

WriteLine("{0} earned {1:C} interest.", jonesAccount.AccountName, jonesAccount.Balance * BankAccount.InterestRate);

WriteLine("{0} earned {1:C} interest.", gerrierAccount.AccountName, gerrierAccount.Balance * BankAccount.InterestRate);

// Constant fields are accessible via the type.
WriteLine($"{bob.Name} is a {Person.Species}.");

// Read-only fields are accessible via the variable.
WriteLine($"{bob.Name} was born on {bob.HomePlanet}.");

/* Book book = new()
{
    Isbn = "978-1803237800",
    Title = "C# 12 and .NET 8 - Modern Cross-Platform Development Fundamentals"
}; */

Book book = new(isbn: "978-1803237800", title: "C# 12 and .NET 8 - Modern Cross-Platform Development Fundamentals")
{
    Author = "Mark J. Price",
    PageCount = 821
};

WriteLine("{0}: {1} written by {2} has {3:N0} pages.", book.Isbn, book.Title, book.Author, book.PageCount);

Person blankPerson = new();

WriteLine("{0} of {1} was created at {2:hh:mm:ss} on {2:dddd}.", blankPerson.Name, blankPerson.HomePlanet, blankPerson.Instantiated);

Person gunny = new("Gunny", "Mars");

WriteLine("{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.", gunny.Name, gunny.HomePlanet, gunny.Instantiated);

bob.WriteToConsole();
WriteLine(bob.GetOrigin());
WriteLine(bob.SayHello());
WriteLine(bob.SayHello("Emily"));
WriteLine(bob.OptionalParameters());
WriteLine(bob.OptionalParameters(number: 52.7, command: "Hide!"));
WriteLine(bob.OptionalParameters("Poke!", active: false));

int a = 10;
int b = 20;
int c = 30;
WriteLine($"Before: a={a}, b={b}, c={c}, d  does not exists yet");
bob.PassingParameters(a, b, ref c, out int d);
WriteLine($"After: a={a}, b={b}, c={c}, d={d}");

var fruit = bob.GetFruit();

WriteLine($"There are {fruit.Number} {fruit.Name}.");

var (name1, dob1) = bob;
WriteLine($"Deconstructed person: {name1}, {dob1}");

var (name2, dob2, fav2) = bob;
WriteLine($"Deconstructed person: {name2}, {dob2}, {fav2}");

// Change to -1 to make the exception handling code execute.
int number = 5;
try
{
    WriteLine($"{number}! is {Person.Factorial(number)}");
}
catch (Exception ex)
{
    WriteLine($"{ex.GetType()} says: {ex.Message} number was {number}.");
}


Person sam = new()
{
    Name = "Sam",
    Born = new(1969, 6, 25, 0, 0, 0, TimeSpan.Zero)
};

WriteLine(sam.Origin);
WriteLine(sam.Greeting);
WriteLine(sam.Age);

sam.Children.Add(new()
{
    Name = "Charlie",
    Born = new(2010, 3, 18, 0, 0, 0, TimeSpan.Zero)
});
sam.Children.Add(new()
{
    Name = "Ella",
    Born = new(2020, 12, 24, 0, 0, 0, TimeSpan.Zero)
});
// Get using Children list.
WriteLine($"Sam's first child is {sam.Children[0].Name}.");
WriteLine($"Sam's second child is {sam.Children[1].Name}.");
// Get using the int indexer.
WriteLine($"Sam's first child is {sam[0].Name}.");
WriteLine($"Sam's second child is {sam[1].Name}.");
// Get using the string indexer.
WriteLine($"Sam's child named Ella is {sam["Ella"].Age} years old.");

Passenger[] passengers = [
    new FirstClassPassanger{AirMiles = 1419,Name="Suman"},
    new FirstClassPassanger{AirMiles = 16562,Name="Lucy"},
    new BusinessClassPassanger{Name="Janice"},
    new CoachClassPassanger{CarryOnKG=25.7,Name="Dave"},
    new CoachClassPassanger{CarryOnKG=0,Name="Amit"},
];

foreach (var passenger in passengers)
{
    decimal flightCost = passenger switch
    {
        //C#8 syntax
        /*  FirstClassPassanger p when p.AirMiles > 35000 => 1500M,
         FirstClassPassanger p when p.AirMiles > 15000 => 1750M,
         FirstClassPassanger _ => 2000M,
         BusinessClassPassanger _ => 1000M,
         CoachClassPassanger p when p.CarryOnKG < 10.0 => 500M,
         CoachClassPassanger _ => 650M,
         _ => 800M, */

        //C# 9 syntax
        FirstClassPassanger p => p.AirMiles switch
        {
            > 35000 => 1500M,
            > 15000 => 1750M,
            _ => 2000M
        },
        BusinessClassPassanger => 1000M,
        CoachClassPassanger p when p.CarryOnKG < 10.0 => 500M,
        CoachClassPassanger => 650M,
        _ => 800M
    };
    WriteLine($"Flight costs {flightCost:C} for {passenger}");
}

ImmutablePerson jeff = new()
{
    FirstName = "Jeff",
    LastName = "Winger"
};

ImmutableVehicle car = new()
{
    Brand = "Mazda MX-5 RF",
    Color = "Soul Red Crystal Metallic",
    Wheels = 4
};

ImmutableVehicle paintedCar = car with
{
    Color = "Polymetal Grey Metallic"
};

WriteLine($"Original car color was {car.Color}.");
WriteLine($"New car color is {paintedCar.Color}.");

AnimalClass ac1 = new() { Name = "Rex" };
AnimalClass ac2 = new() { Name = "Rex" };
WriteLine($"ac1 == ac2: {ac1 == ac2}");
AnimalRecord ar1 = new() { Name = "Rex" };
AnimalRecord ar2 = new() { Name = "Rex" };

WriteLine($"ar1 == ar2: {ar1 == ar2}");

ImmutableAnimal oscar = new("Oscar", "Labrador");

var (who, what) = oscar;

WriteLine($"{who} is a {what}.");

Headset vp = new("Apple", "Vision Pro");

WriteLine($"{vp.ProductName} is made by {vp.Manufacturer}.");

Headset holo = new();

WriteLine($"{holo.ProductName} is made by {holo.Manufacturer}.");

Headset mq = new() { Manufacturer = "Meta", ProductName = "Quest 3" };
WriteLine($"{mq.ProductName} is made by {mq.Manufacturer}.");