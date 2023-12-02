using System.Collections.Immutable;
using AdventOfCode_2023_02;

using var file = File.OpenText("input");

string? line;

int amount = 0;
int allPowers = 0;
while ((line = await file.ReadLineAsync()) != null)
{
    int gameNo = FileParser.ParseGameNumber(line);
    var game = FileParser.ParseShownColors(line).ToImmutableList();
    if (CheckGamePart1(game))
    {
        amount += gameNo;
    }
    allPowers += GetPowerForGamePart2(game);
}
Console.WriteLine(amount);
Console.WriteLine(allPowers);
return;

static bool CheckGamePart1(IEnumerable<(CubeColor, int)> game)
{
    foreach ((var cubeColor, int count) in game)
    {
        if (count > cubeColor.GetRemaining())
        {
            return false;
        }
    }
    return true;
} 

static int GetPowerForGamePart2(IEnumerable<(CubeColor, int)> game)
{
    int r, g, b;
    (r, g, b) = (0,0,0);
    foreach ((var cubeColor, int count) in game)
    {
        switch (cubeColor)
        {
            case CubeColor.Red:
                r = Math.Max(r, count);
                break;
            case CubeColor.Green:
                g = Math.Max(g, count);
                break;
            case CubeColor.Blue:
                b = Math.Max(b, count);
                break;
        }
    }
    
    return r*g*b;
} 