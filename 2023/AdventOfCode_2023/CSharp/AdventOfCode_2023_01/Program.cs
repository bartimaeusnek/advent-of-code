using var file = File.OpenText("input");

string? line;
int maxPt1 = 0;
int maxPt2 = 0;

while ((line = await file.ReadLineAsync()) != null)
{
    maxPt1 += GetNumbersPartOne(line);
    maxPt2 += GetNumbersPartTwo(line);
}

Console.WriteLine("Part 1: " + maxPt1);
Console.WriteLine("Part 2: " + maxPt2);
return;

int GetNumbersPartOne(string linea)
{
    linea = linea.ToLowerInvariant();
   
    char firstPart = linea.First(char.IsNumber);
    char lastPart = linea.Last(char.IsNumber);
    return int.Parse("" + firstPart + lastPart);
}

int GetNumbersPartTwo(string linea)
{
    linea = linea.ToLowerInvariant();
    string[] numbersWritten = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    uint[] firstIndexes = new uint[9];
    int[] lastIndexes = new int[9];
    for (int index = 0; index < numbersWritten.Length; index++)
    {
        uint writtenNum = (uint)linea.IndexOf(numbersWritten[index], StringComparison.InvariantCultureIgnoreCase);
        uint num = (uint)linea.IndexOf(numbers[index], StringComparison.InvariantCultureIgnoreCase);
        firstIndexes[index] = Math.Min(num, writtenNum);

        int writtenNumLast = linea.LastIndexOf(numbersWritten[index], StringComparison.InvariantCultureIgnoreCase);
        int numLast = linea.LastIndexOf(numbers[index], StringComparison.InvariantCultureIgnoreCase);
        lastIndexes[index] = Math.Max(numLast, writtenNumLast);
    }

    int last = Array.IndexOf(lastIndexes, lastIndexes.Max()) + 1;
    int first = Array.IndexOf(firstIndexes, firstIndexes.Min()) + 1;

    return int.Parse("" + first + last);
}