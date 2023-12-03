namespace AdventOfCode_2023_03;

public readonly struct IntVec2 : IEquatable<IntVec2>
{
    public IntVec2(int x, int y)
    {
        X = x;
        Y = y;
    }
    public readonly int X;
    public readonly int Y;

    public bool Equals(IntVec2 other)
    {
        return X == other.X && Y == other.Y;
    }
    public override bool Equals(object? obj)
    {
        return obj is IntVec2 other && Equals(other);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
    public static bool operator ==(IntVec2 left, IntVec2 right)
    {
        return left.Equals(right);
    }
    public static bool operator !=(IntVec2 left, IntVec2 right)
    {
        return !left.Equals(right);
    }
    public static IntVec2 operator +(IntVec2 left, IntVec2 right)
    {
        return new IntVec2(left.X + right.X, left.Y + right.Y);
    }
}