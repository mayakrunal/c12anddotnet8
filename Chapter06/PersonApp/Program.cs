using Packt.Shared;

Person harry = new()
{
    Name = "Harry",
    Born = new(2001, 3, 25, 0, 0, 0, TimeSpan.Zero),
};

harry.WriteToConsole();

// Implementing functionality using methods.
Person lamech = new() { Name = "Lamech" };
Person adah = new() { Name = "Adah" };
Person zillah = new() { Name = "Zillah" };

// Call the instance method to marry Lamech and Adah.
lamech.Marry(adah);

// Call the static method to marry Lamech and Zillah.
//Person.Marry(lamech, zillah);
if (lamech + zillah)
{
    WriteLine($"{lamech.Name} and {zillah.Name} successfully got married.");
}

lamech.OutputSpouses();
adah.OutputSpouses();
zillah.OutputSpouses();

// Call the instance method to make a baby.
Person baby1 = lamech.ProcreateWith(adah);
baby1.Name = "Jabal";
WriteLine($"{baby1.Name} was born on {baby1.Born}");

// Call the static method to make a baby.
Person baby2 = Person.Procreate(lamech, zillah);
baby2.Name = "Tubalcain";

// Use the * operator to "multiply".
Person baby3 = lamech * adah;
baby3.Name = "Jubal";

Person baby4 = zillah * lamech;
baby4.Name = "Naamah";

adah.WriteChildrenToConsole();
zillah.WriteChildrenToConsole();
lamech.WriteChildrenToConsole();

lamech.Children.ForEach(child => WriteLine($"   {lamech.Name}'s child is named {child.Name}"));

// Non-generic lookup collection.
System.Collections.Hashtable lookupObject = new()
{
    { 1, "Alpha" },
    { 2, "Beta" },
    { 3, "Gamma" },
    { harry, "Delta" }
};

int key = 2; // Look up the value that has 2 as its key.
WriteLine("Key {0} has value: {1}", key, lookupObject[key]);

// Look up the value that has harry as its key.
WriteLine(format: "Key {0} has value: {1}", harry, lookupObject[harry]);

Dictionary<int, string> lookupIntString = [];
lookupIntString.Add(1, "Alpha");
lookupIntString.Add(2, "Beta");
lookupIntString.Add(3, "Gamma");
lookupIntString.Add(4, "Delta");

key = 3; // Look up the value that has 2 as its key.
WriteLine("Key {0} has value: {1}", key, lookupIntString[key]);

// Assign the method to the Shout delegate.
harry.Shout += Harry_Shout;
harry.Shout += Harry_Shout_2;

// Call the Poke method that eventually raises the Shout event.
harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();

Person?[] people =
[
    null,
    new() { Name = "Simon" },
    new() { Name = "Jenny" },
    new() { Name = "Adam" },
    new() { Name = null },
    new() { Name = "Richard" }
];
OutputPeopleNames(people, "Initial list of people:");

Array.Sort(people);

OutputPeopleNames(people, "After sorting using Person's IComparable implementation:");

Array.Sort(people, new PersonComparer());

OutputPeopleNames(people, "After sorting using Person's IComparer implementation:");

DisplacementVector dv1 = new(3, 5);
DisplacementVector dv2 = new(-2, 7);
DisplacementVector dv3 = dv1 + dv2;
WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X},{dv3.Y})");

DisplacementVector dv4 = new();
WriteLine($"({dv4.X}, {dv4.Y})");

DisplacementVector dv5 = new(3, 5);
WriteLine($"dv1.Equals(dv5): {dv1.Equals(dv5)}");
WriteLine($"dv1 == dv5: {dv1 == dv5}");

Employee john = new()
{
    Name = "John Jones",
    Born = new(1990, 7, 28, 0, 0, 0, TimeSpan.Zero),
    EmployeeCode = "JJ001",
    HireDate = new(2014, 11, 23)
};

john.WriteToConsole();
WriteLine(john.ToString());

Employee aliceInEmployee = new() { Name = "Alice", EmployeeCode = "AA123" };
Person aliceInPerson = aliceInEmployee;
aliceInEmployee.WriteToConsole();
aliceInPerson.WriteToConsole();
WriteLine(aliceInEmployee.ToString());
WriteLine(aliceInPerson.ToString());

if (aliceInPerson is Employee explicitAlice)
{
    WriteLine($"{nameof(aliceInPerson)} is an Employee.");
}

try
{
    john.TimeTravel(when: new(1999, 12, 31));
    john.TimeTravel(when: new(1950, 12, 25));
}
catch (PersonException ex)
{
    WriteLine(ex.Message);
}

string email1 = "pamela@test.com";
string email2 = "ian&test.com";

WriteLine("{0} is a valid e-mail address: {1}", email1, email1.IsValidEmail());
WriteLine("{0} is a valid e-mail address: {1}", email2, email2.IsValidEmail());


C1 c1 = new() { Name = "Bob" };
c1.Name = "Bill";
C2 c2 = new(Name: "Bob");
//c2.Name = "Bill"; // CS8852: Init-only property.
S1 s1 = new() { Name = "Bob" };
s1.Name = "Bill";
S2 s2 = new(Name: "Bob");
s2.Name = "Bill";
S3 s3 = new(Name: "Bob");
//s3.Name = "Bill"; // CS8852: Init-only property.