namespace AdventOfCode_2023_02;

public class FileParser
{
    private const string Preamble = "Game ";
    private const string PreambleEnd = ": ";
    private const string inBetween = "; ";
    
    private static int GetGameBegin(string line)
    {
        return line.IndexOf(PreambleEnd, StringComparison.InvariantCultureIgnoreCase);
    }
    
    private static int GetGameSectionEnd(string line)
    {
        int next = line.IndexOf(inBetween, StringComparison.InvariantCultureIgnoreCase);
        return next == -1 ? line.Length : next;
    }
    
    public static int ParseGameNumber(string line)
    {
        return int.Parse(line[Preamble.Length..GetGameBegin(line)]);
    }

    public static IEnumerable<(CubeColor, int)> ParseShownColors(string line)
    {
        line = line[(GetGameBegin(line) + 2)..];
        int end = GetGameSectionEnd(line);
        while (true)
        {
            string currentGame = line[..end];
            string[] balls = currentGame.Split(", ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            foreach (string ball in balls)
            {
                string[] split = ball.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

                if (!Enum.TryParse(typeof(CubeColor), split[1], true, out object? color))
                    throw new Exception($"ParsingFailed for {ball}!");

                yield return ((CubeColor)color, int.Parse(split[0]));
            }
            
            if (end == line.Length)
            {
                yield break; 
            }
            
            line = line[(end + 2)..];
            end = GetGameSectionEnd(line);
        }
    }
    
}