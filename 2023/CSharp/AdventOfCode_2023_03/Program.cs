using AdventOfCode_2023_03;

using static AdventOfCode_2023_03.Node;

using (var fileparser = new FileParser("input"))
{
    await fileparser.ReadFileAsync();
}
Console.WriteLine(Part1());
ResetField();
Console.WriteLine(Part2());
return;

static int Part1()
{
    var returnValue = 0;
    var maxX = Nodes.Max(x => x.Key.X);
    var maxY = Nodes.Max(x => x.Key.Y);
    Node current;

    for (int y = 0; y < maxY; y++)
    {
        for (int x = 0; x < maxX; x++)
        {
            if (!Nodes.TryGetValue(new IntVec2(x, y), out current))
                continue;
            if (current.Content is '.' || current.IsNumber)
                continue;
            foreach (var orientation in OrientationsExtensions.GetAllOrientations())
            {
                var direction = orientation.GetDirection();
                if (!Nodes.TryGetValue(current.Coords + direction, out var neighbour))
                    continue;
                if (neighbour.IsNumber)
                {
                    returnValue += neighbour.GetCompoundValue();
                }
            }
        }
    }
    return returnValue;
}

static int Part2()
{
    var returnValue = 0;
    var maxX = Nodes.Max(x => x.Key.X);
    var maxY = Nodes.Max(x => x.Key.Y);
    Node current;

    for (int y = 0; y < maxY; y++)
    {
        for (int x = 0; x < maxX; x++)
        {
            if (!Nodes.TryGetValue(new IntVec2(x, y), out current))
                continue;
            if (current.Content != '*')
                continue;
            var ajencency = 0;
            foreach (var orientation in OrientationsExtensions.GetAllOrientations())
            {
                var direction = orientation.GetDirection();
                if (!Nodes.TryGetValue(current.Coords + direction, out var neighbour))
                    continue;
                if (!neighbour.IsNumber)
                    continue;
                if (neighbour.GetCompoundValue() > 0)
                {
                    ++ajencency;
                }
            }
            ResetField();
            var num1 = 0;
            if (ajencency != 2)
                continue;
            foreach (var orientation in OrientationsExtensions.GetAllOrientations())
            {
                var direction = orientation.GetDirection();
                if (!Nodes.TryGetValue(current.Coords + direction, out var neighbour))
                    continue;
                if (!neighbour.IsNumber)
                    continue;

                if (num1 == 0)
                    num1 = neighbour.GetCompoundValue();
                else
                    returnValue += num1 * neighbour.GetCompoundValue();
            }
        }
    }
    return returnValue;
}