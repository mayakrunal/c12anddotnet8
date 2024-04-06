string name = "Samantha Jones";
// Getting the lengths of the first and last names.
int lengthOfFirst = name.IndexOf(' ');
int lengthOfLast = name.Length - lengthOfFirst - 1;

// Using Substring.
string firstName = name.Substring(0, length: lengthOfFirst);
string lastName = name.Substring(name.Length - lengthOfLast, lengthOfLast);
WriteLine($"First: {firstName}, Last: {lastName}");

// Using spans.
ReadOnlySpan<char> nameAsSpan = name.AsSpan();
ReadOnlySpan<char> firstNameSpan = nameAsSpan[..lengthOfFirst];
ReadOnlySpan<char> lastNameSpan = nameAsSpan[^lengthOfLast..];

WriteLine($"First: {firstNameSpan}, Last: {lastNameSpan}");