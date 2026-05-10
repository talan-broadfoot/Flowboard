using ConsoleApp1;

Project flowboard = new Project();
flowboard.Name = "Flowboard";
flowboard.TaskCount = 0;
flowboard.IsComplete = false;

void PrintProjectDetails(Project project)
{
    Console.WriteLine($"Project: {project.Name}");
    Console.WriteLine($"Tasks: {project.TaskCount}");
    Console.WriteLine($"Complete: {project.IsComplete}");
}
PrintProjectDetails(flowboard);