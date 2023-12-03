namespace AdventOfCode_2023_03;

using System.Text;

public class Node
{
    public readonly char Content;
    public readonly IntVec2 Coords;
    public bool HasBeenAdded;

    public bool IsNumber
    {
        get
        {
            return char.IsNumber(Content);
        }
    }

    public int GetCompoundValue()
    {
        if (HasBeenAdded)
            return 0;
        var west = Orientations.W.GetDirection();
        Node? node;
        
        while (Nodes.TryGetValue(Coords + west, out node) && node.IsNumber)
        {
            west = new IntVec2(west.X - 1, 0);
        }
        node ??= this;
        var east = Orientations.E.GetDirection();
        if (node.IsNumber is false)
        {
            node = Nodes[node.Coords + east]; //go back one
        }
        StringBuilder sb = new();
        do
        {
            sb.Append(node.Content);
            node.HasBeenAdded = true;
        } while (Nodes.TryGetValue(node.Coords + east, out node) && node.IsNumber);
        return int.Parse(sb.ToString());
    }
    
    public Node(char content, IntVec2 coords, bool add = true)
    {
        Content = content;
        Coords = coords;
        if (add)
        {
            Nodes.Add(Coords, this);
        }
    }

    public static void ResetField()
    {
        foreach (var nodesValue in Nodes.Values)
        {
            nodesValue.HasBeenAdded = false;
        }
    }

    public static Dictionary<IntVec2, Node> Nodes { get; } = new ();
}