namespace Stream_Processing;

internal class FileWorker : IDisposable
{
    private readonly FileStream _stream;

    private readonly Logger _logger;

    private readonly string path;

    public FileWorker(string path, Logger logger)
    {
        if (path == null) throw new ArgumentNullException("Path argument cannot be null");

        if (!File.Exists(path)) throw new FileNotFoundException("File with given path doesn't exists");

        _logger = logger;
        this.path = path;
        _stream = File.Open(path, FileMode.Open);
        _logger.Log($"File on path {path} is open.");
    }

    public List<string> ReadTextLines()
    {
        using StreamReader sr = new StreamReader(this._stream);

        List<string> textLines = new();

        int index = 0;
        while (true)
        {
            index++;
            _logger.Log($"Reading line {index} from the file on path {path}");
            string? line = sr.ReadLine();
            if (line == null) break;
            textLines.Add(line);
        }

        return textLines;
    }

    public void WriteTextLines(List<string> textLines)
    {
        using StreamWriter sw = new StreamWriter(this._stream);

        int index = 0;
        foreach (string line in textLines)
        {
            index++;
            _logger.Log($"Writing line {index} to the file on path {path}");
            sw.WriteLine(line);
        }
    }

    public void Dispose()
    {
        Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _stream.Dispose();
            _logger.Log($"File on path {path} is closed");
        }
    }
}
