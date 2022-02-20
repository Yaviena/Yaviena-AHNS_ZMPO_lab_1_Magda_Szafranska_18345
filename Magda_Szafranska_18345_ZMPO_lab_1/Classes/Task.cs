using System;

namespace ToDoList_MagdaSzafranska
{
    internal class Task : TaskBase      // INHERITANCE
    {
        // CONSTRUCTORS
        static Task()                   // static constructor
        {
            CurrentTaskNumber = 0;      // an initialization of static element before creating a class TaskBase object
        }
        public Task()                   // default constructor
        {
            TaskName = "default task";
            CurrentTaskNumber++;        // increasing tasks counter by 1 each time when new object (task) is creating
        }
        public Task(string taskName)    // overloaded constructor
        {
            this.TaskName = taskName;
            CurrentTaskNumber++;
        }

        // METHODS
        public override void MenuColourChange()                   // method to change colour in console
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
