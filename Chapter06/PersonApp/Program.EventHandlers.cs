using Packt.Shared; // To use Person.

public partial class Program
{
    //A method to handle the Shout event received by the harry object

    private static void Harry_Shout(object? sender, EventArgs e)
    {
        if (sender is null) return;
        if (sender is not Person p) return;
        WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
    }

    // Another method to handle the event received by the harry object.
    private static void Harry_Shout_2(object? sender, EventArgs e)
    {
        WriteLine("Stop it!");
    }

    
}
