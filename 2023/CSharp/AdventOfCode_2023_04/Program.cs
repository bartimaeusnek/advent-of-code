using AdventOfCode_2023_04;

using var file = File.OpenText("input");
string? line;
int amount = 0;
var queue = new List<int>();
int regular = 0;
while ((line = await file.ReadLineAsync()) != null)
{
    amount += Part1(line);
    Part2(line, queue);
    ++regular;
}
Console.WriteLine(amount);
Console.WriteLine(regular + queue.Count);
return;

static int Part1(string line)
{
    int[] winningNumbers = FileParser.GetNumbers(line[FileParser.GetWinningCardRange(line)]).ToArray();
    int[] data = FileParser.GetNumbers(line[FileParser.GetDataRange(line)]).ToArray();
    int returnValue = 0;
    foreach (int i in data)
    {
        if (!winningNumbers.Contains(i))
            continue;
        if (returnValue == 0)
        {
            ++returnValue;
        }
        else
        {
            returnValue *= 2;
        }
    }
    return returnValue;
}

static void Part2(string line, IList<int> extras)
{
    int gameNo = FileParser.ParseGameNumber(line);
    int[] winningNumbers = FileParser.GetNumbers(line[FileParser.GetWinningCardRange(line)]).ToArray();
    int[] data = FileParser.GetNumbers(line[FileParser.GetDataRange(line)]).ToArray();
    int toAdd = gameNo;
    for (int i = 0; i < data.Length; i++)
    {
        int d = data[i];
        if (!winningNumbers.Contains(d))
            continue;
        extras.Add(++toAdd);
        
        int count = extras.Count;
        for (int index = 0; index < count; index++)
        {
            int x = extras[index];
            if (x == gameNo)
                extras.Add(toAdd);
        }
    }
}
