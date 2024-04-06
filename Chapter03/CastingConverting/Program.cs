using static System.Convert;
using System.Globalization; // To use CultureInfo.

int a = 10;
double b = a;

WriteLine($"a is {a}, b is {b}");

double c = 9.8;
int d = (int)c; // Compiler gives an error if you do not explicitly cast.
WriteLine($"c is {c}, d is {d}");

long e = 10;
int f = (int)e;
WriteLine($"e is {e:N0}, f is {f:N0}");

e = long.MaxValue;
f = (int)e;
WriteLine($"e is {e:N0}, f is {f:N0}");

WriteLine("{0,12} {1,34}", "Decimal", "Binary");
WriteLine("{0,12} {0,34:B32}", int.MaxValue);
for (int i = 8; i >= -8; i--)
{
    WriteLine("{0,12} {0,34:B32}", i);
}
WriteLine("{0,12} {0,34:B32}", int.MinValue);

double g = 9.8;
int h = ToInt32(g);
WriteLine($"g is {g}, h is {h}");

double[,] doubles = {
{ 9.49, 9.5, 9.51 },
{ 10.49, 10.5, 10.51 },
{ 11.49, 11.5, 11.51 },
{ 12.49, 12.5, 12.51 } ,
{ -12.49, -12.5, -12.51 },
{ -11.49, -11.5, -11.51 },
{ -10.49, -10.5, -10.51 },
{ -9.49, -9.5, -9.51 }
};
WriteLine($"| double | ToInt32 | double | ToInt32 | double | ToInt32 |");
for (int x = 0; x < 8; x++)
{
    for (int y = 0; y < 3; y++)
    {
        Write($"| {doubles[x, y],6} | {ToInt32(doubles[x, y]),7} ");
    }
    WriteLine("|");
}
WriteLine();

// Allocate an array of 128 bytes.
byte[] binaryObject = new byte[128];

// Populate the array with random bytes.
Random.Shared.NextBytes(binaryObject);

WriteLine("Binary Object as bytes:");

for (int index = 0; index < binaryObject.Length; index++)
{
    Write($"{binaryObject[index]:X2} ");
}

WriteLine();

// Convert the array to Base64 string and output as text.
string encoded = ToBase64String(binaryObject);
WriteLine($"Binary Object as Base64: {encoded}");

// Set the current culture to make sure date parsing works.
CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

int friends = int.Parse("27");

DateTime birthday = DateTime.Parse("4 June 1980");

WriteLine($"I have {friends} friends to invite to my party.");
WriteLine($"My birthday is {birthday}.");
WriteLine($"My birthday is {birthday:D}.");

Write("How many eggs are there? ");
string? input = ReadLine();
if (int.TryParse(input, out int count))
{
    WriteLine($"There are {count} eggs.");
}
else
{
    WriteLine("I could not parse the input.");
}

