namespace AdventOfCode_2023_04;

public class FileParser
{
    private const string Preamble = "Game ";
    private const string PreambleEnd = ": ";
    private const string InBetween = "| ";
    
    private static int GetGameBegin(string line)
    {
        return line.IndexOf(PreambleEnd, StringComparison.InvariantCultureIgnoreCase);
    }

    public static Range GetWinningCardRange(string line)
    {
        return new Range(GetGameBegin(line) + PreambleEnd.Length, GetGameSectionEnd(line));
    }
    
    public static Range GetDataRange(string line)
    {
        return new Range(GetGameSectionEnd(line) + InBetween.Length, ^0);
    }

    public static IEnumerable<int> GetNumbers(string section)
    {
        string[] rawNumbers = section.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        foreach (string rawNumber in rawNumbers)
        {
            yield return int.Parse(rawNumber);
        }
    }
    
    private static int GetGameSectionEnd(string line)
    {
        int next = line.IndexOf(InBetween, StringComparison.InvariantCultureIgnoreCase);
        return next == -1 ? line.Length : next;
    }
    
    public static int ParseGameNumber(string line)
    {
        return int.Parse(line[Preamble.Length..GetGameBegin(line)].Trim());
    }
    
}