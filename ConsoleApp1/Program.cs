using ConsoleApp1;

Project flowboard = new Project();
flowboard.Name = "Flowboard";
flowboard.TaskCount = 0;
flowboard.IsComplete = false;
Console.WriteLine($"Project: {flowboard.Name}");
Console.WriteLine($"Tasks: {flowboard.TaskCount}");
Console.WriteLine($"Complete: {flowboard.IsComplete}");