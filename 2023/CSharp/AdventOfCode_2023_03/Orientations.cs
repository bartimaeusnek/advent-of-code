namespace AdventOfCode_2023_03;

public enum Orientations
{
    N,
    NW,
    W,
    SW,
    S,
    SE,
    E,
    NE
}
public static class OrientationsExtensions
{
    public static IEnumerable<Orientations> GetAllOrientations()
    {
        yield return Orientations.N;
        yield return Orientations.NW;
        yield return Orientations.W;
        yield return Orientations.SW;
        yield return Orientations.S;
        yield return Orientations.SE;
        yield return Orientations.E;
        yield return Orientations.NE;
    }

    public static IntVec2 GetDirection(this Orientations orientations)
    {
        return orientations switch
        {
            Orientations.N => new IntVec2(0, -1),
            Orientations.NW => new IntVec2(-1, -1),
            Orientations.W => new IntVec2(-1, 0),
            Orientations.SW => new IntVec2(-1, 1),
            Orientations.S => new IntVec2(0, 1),
            Orientations.SE => new IntVec2(1, 1),
            Orientations.E => new IntVec2(1, 0),
            Orientations.NE => new IntVec2(1, -1),
            _ => throw new ArgumentOutOfRangeException(nameof(orientations), orientations, null)
        };
    }
}