if (args.Length < 3)
{
    WriteLine("You must specify two colors and cursor size, e.g.");
    WriteLine("dotnet run red yellow 50");
    return; // Stop running.
}

ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), args[0], true);

BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), args[0], true);

try
{
    CursorSize = int.Parse(args[2]);
}
catch (PlatformNotSupportedException)
{
    WriteLine("The current platform does not support changing the size of the cursor.");
}