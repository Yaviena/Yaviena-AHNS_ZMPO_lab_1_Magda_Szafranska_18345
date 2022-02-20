using System;

namespace ToDoList_MagdaSzafranska
{
    /// <summary>
    /// A base class to store static const elements and private fields concern tasks
    /// </summary>
    internal class TaskBase
    {
        // DATA ELEMENENTS (FIELDS)
        private string _taskName;
        private static int _currentTaskNumber;                  // amount of all tasks in program
        public const string filePath = "TODO_tasksList.txt";    // a constant of global scope

        // PROPERTIES WITH SETTERS ANG GETTERS
        public string TaskName                                  // a property stores the task name
        {
            get { return _taskName; }
            set { _taskName = value; }
        }                               
        public static int CurrentTaskNumber                     // a property keeping amount of tasks in app (has acces to private variable) 
        {
            get { return _currentTaskNumber; }
            set
            {
                if (value >= 0)                                 // check if the number of tasks is grater than zero
                    _currentTaskNumber = value;
                else
                    _currentTaskNumber = -1;
            }
        }

        // METHODS
        public static void CurrentTasksNumber()                 // a method to show the number of tasks in the app
        {
            Console.WriteLine("Amount of tasks: " + CurrentTaskNumber);
        }
        public static void MenuColourBack()                     // a method to back to the default (white) colour in console
        {
            Console.ResetColor();
        }

        // VIRTUAL METHODS (TO OVERRIDE IN INHERITED CLASSES - POLYMORPHISM)
        virtual public void MenuColourChange()                   // a method to change colour in console
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
    }
}
