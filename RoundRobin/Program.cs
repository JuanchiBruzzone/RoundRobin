using RoundRobin;

//RoundRobinFileWriter fileWriter = new();

//fileWriter.AddDirectory("/home/juanchi/Documents/Test1");
//fileWriter.AddDirectory("/home/juanchi/Documents/Test2");
//fileWriter.AddDirectory("/home/juanchi/Documents/Test3");

//fileWriter.WriteFile("File content 1");
//fileWriter.WriteFile("File content 2");
//fileWriter.WriteFile("File content 3");

RoundRobinProcessRunner processRunner = new();

// Add processes to the scheduler
Console.WriteLine("Process 1: LS, list contents of directory. ");
processRunner.AddProcess("/bin/ls");

Console.WriteLine("Process 2: PING, ping google DNS 8.8.8.8 ");
processRunner.AddProcess("/usr/bin/ping");

Console.WriteLine("Process 3: Get Ubuntu Version ");
processRunner.AddProcess("/usr/bin/lsb_release");

Console.WriteLine();

// Run processes using the round-robin algorithm
processRunner.RunNextProcess();
processRunner.RunNextProcess(" -c 4 8.8.8.8");
processRunner.RunNextProcess(" -a");


