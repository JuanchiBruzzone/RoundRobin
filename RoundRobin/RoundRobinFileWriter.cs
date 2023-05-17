namespace RoundRobin;

public class RoundRobinFileWriter
{
    private readonly RoundRobinScheduler<string> directoryScheduler;

    public RoundRobinFileWriter()
    {
        directoryScheduler = new RoundRobinScheduler<string>();
    }

    public void AddDirectory(string directory)
    {
        if (!Directory.Exists(directory))
            throw new DirectoryNotFoundException($"Directory '{directory}' not found.");

        directoryScheduler.AddItem(directory);
    }

    public void WriteFile(string content)
    {
        string directory = directoryScheduler.GetNextItem();
        string fileName = $"file_{DateTime.Now:yyyyMMddHHmmss}.txt";
        string filePath = Path.Combine(directory, fileName);

        File.WriteAllText(filePath, content);

        Console.WriteLine($"File '{filePath}' written successfully.");
    }
}
