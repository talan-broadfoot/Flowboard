using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Project : IProject
    {
        public string Name;
        public TaskStatus Status;
        public List<Task> Tasks = new List<Task>();
        private int _taskCount;
        public int TaskCount
        {
            get { return _taskCount; }
            set
            {
                if (value >= 0)
                    _taskCount = value;
            }
        }
        public void Start()
        {
            Console.WriteLine("Project started");
        }
        public void Complete()
        {
            Console.WriteLine("Project completed");
        }
        public string Description;
    }
}   
