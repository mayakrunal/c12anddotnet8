// An unsigned integer is a positive whole number or 0.
uint naturalNumber = 23;

// An integer is a negative or positive whole number or 0.
int integerNumber = -23;

// A float is a single-precision floating-point number.
// The F or f suffix makes the value a float literal.
// The suffix is required to compile.
float realNumber = 2.3f;

// A double is a double-precision floating-point number.
// double is the default for a number value with a decimal point.
double anotherRealNumber = 2.3; // A double literal value.

int decimalNotation = 2_000_000;
int binaryNotation = 0b_0001_1110_1000_0100_1000_0000;
int hexadecimalNotation = 0x_001E_8480;

// Check the three variables have the same value.
WriteLine($"{decimalNotation == binaryNotation}");
WriteLine($"{decimalNotation == hexadecimalNotation}");

// Output the variable values in decimal.
WriteLine($"{decimalNotation:N0}");
WriteLine($"{binaryNotation:N0}");
WriteLine($"{hexadecimalNotation:N0}");

// Output the variable values in hexadecimal.
WriteLine($"{decimalNotation:X}");
WriteLine($"{binaryNotation:X}");
WriteLine($"{hexadecimalNotation:X}");


WriteLine($"int uses {sizeof(int)} bytes and can store numbers in the range {int.MinValue:N0} to {int.MaxValue:N0}.");
WriteLine($"double uses {sizeof(double)} bytes and can store numbers in the range {double.MinValue:N0} to {double.MaxValue:N0}.");
WriteLine($"decimal uses {sizeof(decimal)} bytes and can store numbers in the range {decimal.MinValue:N0} to {decimal.MaxValue:N0}.");

unsafe
{
    WriteLine($"Half uses {sizeof(Half)} bytes and can store numbers in the range {Half.MinValue:N0} to {Half.MaxValue:N0}.");
    WriteLine($"Int128 uses {sizeof(Int128)} bytes and can store numbers in the range {Int128.MinValue:N0} to {Int128.MaxValue:N0}.");
}