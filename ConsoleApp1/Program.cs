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
            Console.WriteLine("Enter project name:");
            string name = Console.ReadLine();
            Project newProject = new Project();
            newProject.Name = name;
            newProject.TaskCount = 0;
            newProject.IsComplete = false;
            projectList.Add(newProject);
            Console.WriteLine($"Project {newProject.Name} has been added successfully");
            break;
        case "2":
            if (projectList.Count == 0)
            {
                Console.WriteLine("No projects available to add task.");
                break;
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
                newTask.IsComplete = false;
                projectList[projectIndex].Tasks.Add(newTask);
                Console.WriteLine($"Task {newTask.Name} has been added.");
            }
            catch
            {
                Console.WriteLine("You must enter a valid number.");
            }
            break;
        case "3":
            {
                if (projectList.Count == 0)
                {
                    Console.WriteLine("No projects available to complete tasks.");
                    break;
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
                    projectList[projectIndex].Tasks[taskIndex].IsComplete = true;
                    Console.WriteLine("Task marked as complete!");
                }
                catch
                {
                    Console.WriteLine("You must enter a valid number.");
                }
                break;
            }
        case "4":
            Console.WriteLine("Projects Added:");
            foreach (Project p in projectList)
            {
                Console.WriteLine($"{p.Name}");
                foreach (ConsoleApp1.Task t in p.Tasks)
                {
                    Console.WriteLine($"Task: {t.Name}");
                }
            }
            return;
    }    
}