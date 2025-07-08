namespace Stream_Processing;

internal class Logger : IDisposable
{
    private string logFilePath = "log.txt";

    private FileStream logStream;

    private StreamWriter logWriter;

    public Logger()
    {
        logStream = File.Open(logFilePath, FileMode.OpenOrCreate);
        logStream.Seek(0, SeekOrigin.End);
        logWriter = new StreamWriter(logStream);
    }

    public void Log(string message)
    {
        logWriter.WriteLine(message);
    }

    public void Dispose()
    {
        logWriter.Dispose();
        logStream.Dispose();
    }
}
