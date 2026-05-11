using ConsoleApp1;
List<Project> projectList = new List<Project>();

while (true)
{ 
    Console.WriteLine("Enter project name:");
    string name = Console.ReadLine();
    if (name == "quit")
    {
        break;
    }
    Project newProject = new Project();
    newProject.Name = name;
    newProject.TaskCount = 0;
    newProject.IsComplete = false;
    projectList.Add(newProject);
    Console.WriteLine($"Project {newProject.Name} has been added successfully");
}
Console.WriteLine("Projects Added:");
foreach  (Project p in projectList)
{
    Console.WriteLine($"{p.Name}");
}