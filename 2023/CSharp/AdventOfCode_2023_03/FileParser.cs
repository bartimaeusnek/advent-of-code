namespace AdventOfCode_2023_03;

public class FileParser : IDisposable
{
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _fileStream.Dispose();
        }
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    private StreamReader _fileStream;
    public FileParser(string path)
    {
        _fileStream = File.OpenText(path);
    }

    public async Task ReadFileAsync()
    {
        string? line;
        var y = 0;
        while ((line = await _fileStream.ReadLineAsync()) != null)
        {
            var single = line.ToCharArray();
            var x = 0;
            foreach (char c in single)
            {
                _ = new Node(c, new IntVec2(x++, y));
            }
            ++y;
        }
    }
}