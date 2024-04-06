using System.Diagnostics.CodeAnalysis;

namespace Packt.Shared;


public class Book
{
    // Needs .NET 7 or later as well as C# 11 or later.
    public required string? Isbn;
    public required string? Title;

    public string? Author;
    public int PageCount;

    public Book() { }

    [SetsRequiredMembers]
    public Book(string? isbn, string? title)
    {
        Isbn = isbn;
        Title = title;
    }
}
