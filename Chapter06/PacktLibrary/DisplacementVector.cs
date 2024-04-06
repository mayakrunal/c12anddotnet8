namespace Packt.Shared;

public record struct DisplacementVector(int X, int Y)
{
    public static DisplacementVector operator +(DisplacementVector vector1, DisplacementVector vector2)
    {
        return new(vector1.X + vector2.X, vector1.Y + vector2.Y);
    }
}
