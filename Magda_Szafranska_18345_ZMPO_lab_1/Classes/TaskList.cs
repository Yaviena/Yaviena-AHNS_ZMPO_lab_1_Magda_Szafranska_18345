using System;
using System.Collections.Generic;

namespace ToDoList_MagdaSzafranska
{
    internal class TaskList
    {
        private List<Task> listOfTasks = new List<Task>();  // a private object of List<Task>

        public static void AddNewTask(string newTask)
        {
            FileService.SaveTask(new Task(newTask));        // save every single task to the file in FileService class
        }
    }
}
