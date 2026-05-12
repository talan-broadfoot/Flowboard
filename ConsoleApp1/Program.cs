using ConsoleApp1;
using System.Numerics;
using System.Xml.Linq;
List<Project> projectList = new List<Project>();

while (true)
{ 
    Console.WriteLine("Welcome to Flowboard please choose an option\n1. Add Project\n2. Add Task\n3. Mark Task Complete\n4. Quit");
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            {
                // Asks user for project name and adds it to the list
                AddProject(projectList);
                break;
            }
        case "2":
            {
                // Asks user for which project they want to add the task to, asks for task name and confirms it was added
                AddTask(projectList);
                break;
            }
        case "3":
            {
                //Asks user for which project and then which task they would like to mark complete and confirms it was marked
                MarkTaskComplete(projectList);
                break;
            }
        case "4":
            {
                //Prints summary of what was done during the session after choosing to quit
                PrintSummary(projectList);
                return;
            }
    }    
}
void AddProject(List<Project> projectList)
{
    Console.WriteLine("Enter project name:");
    string name = Console.ReadLine();
    Project newProject = new Project();
    newProject.Name = name;
    newProject.TaskCount = 0;
    newProject.Status = ConsoleApp1.TaskStatus.NotStarted;
    projectList.Add(newProject);
    Console.WriteLine($"Project {newProject.Name} has been added successfully");
}
void AddTask(List<Project> projectList)
{
    if (projectList.Count == 0)
    {
        Console.WriteLine("No projects available to add task.");
        return;
    }
    for (int i = 0; i < projectList.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {projectList[i].Name}");
    }
    Console.WriteLine("Please enter project number:");
    string taskChoice = Console.ReadLine();
    try
    {
        int projectIndex = int.Parse(taskChoice) - 1;
        Console.WriteLine("Please enter task name:");
        string taskName = Console.ReadLine();
        ConsoleApp1.Task newTask = new ConsoleApp1.Task();
        newTask.Name = taskName;
        newTask.Status = ConsoleApp1.TaskStatus.NotStarted;
        projectList[projectIndex].Tasks.Add(newTask);
        Console.WriteLine($"Task {newTask.Name} has been added.");
    }
    catch
    {
        Console.WriteLine("You must enter a valid number.");
    }
}
void MarkTaskComplete(List<Project> projectList)
{
    if (projectList.Count == 0)
    {
        Console.WriteLine("No projects available to complete tasks.");
        return;
    }
    for (int i = 0; i < projectList.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {projectList[i].Name}");
    }
    Console.WriteLine("Please enter project number");
    string projectNumber = Console.ReadLine();
    try
    {
        int projectIndex = int.Parse(projectNumber) - 1;
        for (int i = 0; i < projectList[projectIndex].Tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {projectList[projectIndex].Tasks[i].Name}");
        }
        Console.WriteLine("Please enter task number:");
        string taskNumber = Console.ReadLine();
        int taskIndex = int.Parse(taskNumber) - 1;
        projectList[projectIndex].Tasks[taskIndex].Status = ConsoleApp1.TaskStatus.Complete;
        Console.WriteLine("Task marked as complete!");
    }
    catch
    {
        Console.WriteLine("You must enter a valid number.");
    }
}
void PrintSummary(List<Project> projectList)
{
    Console.WriteLine("Projects Added:");
    foreach (Project p in projectList)
    {
        Console.WriteLine($"== {p.Name} ==");
        foreach (ConsoleApp1.Task t in p.Tasks)
        {
            Console.WriteLine($"Tasks: {t.Name} - Status: {t.Status}");
        }
    }
}