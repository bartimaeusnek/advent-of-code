namespace AdventOfCode_2023_02;
using static CubeColor;
public enum CubeColor
{
    Red,
    Green,
    Blue
}

public static class CubeColorExtensions
{
    private static Dictionary<CubeColor, int> _cubes = new()
    {
        {
            Red, 12
        },
        {
            Green, 13
        },
        {
            Blue, 14
        }
    };
    
    public static int GetRemaining(this CubeColor color)
    {
        return _cubes[color];
    }
}