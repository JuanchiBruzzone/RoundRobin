using System.Diagnostics;

namespace RoundRobin;

public class RoundRobinProcessRunner
{
    private readonly RoundRobinScheduler<string> processScheduler;

    public RoundRobinProcessRunner()
    {
        processScheduler = new RoundRobinScheduler<string>();
    }

    public void AddProcess(string processPath)
    {
        if (!System.IO.File.Exists(processPath))
            throw new System.IO.FileNotFoundException($"Process '{processPath}' not found.");

        processScheduler.AddItem(processPath);
    }

    public void RunNextProcess(string? argument = "")
    {
        string processPath = processScheduler.GetNextItem();

        Process process = new Process();
        process.StartInfo.FileName = processPath;
        process.StartInfo.Arguments = argument;
        process.Start();
        process.WaitForExit();

        Console.WriteLine($"Process '{processPath}' finished executing.");
        Console.WriteLine();
    }
}
