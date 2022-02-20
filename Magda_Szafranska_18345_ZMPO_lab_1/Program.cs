using System;

namespace ToDoList_MagdaSzafranska
{
    class Program
    {
        static void Main(string[] args)
        {
            char choice;                                // stores a user choice from the menu
            TaskBase tb1 = new TaskBase();              // an object of TaskBase class
            Task tb2 = new Task();                      // an object of Task class
            Helpers.Menu(tb1);                          // invoke a method of menu with the object parameter
            FileService.ReadTasks();                    // read all tasks saved previously in the file

            
            #region Loop to feed by user
            do                                          // a do while loop: asks user to choose another number until he wants to exit (by choosing nr '6')
            {
                choice = Helpers.ChooseOption(tb2);     // ask user about the number
                switch (choice)                         // switch depending on the user choice
                {
                    case '1':                           // show list of tasks which user typed in (from the older order)
                        {
                            FileService.ShowTasksFromFile();
                            break;                      // breaking the switch
                        }
                    case '2':                           // show all tasks from the newest to the older order
                        {
                            FileService.ShowFromTheNewest();
                            break;
                        }
                    case '3':                           // input a new task by user (execute in TaskList class)
                        {
                            Console.Write("TASK NAME: ");
                            TaskList.AddNewTask(Console.ReadLine());
                            break;
                        }
                    case '4':                           // remove one task from the list of tasks
                        {
                            FileService.RemoveOneTask();
                            break;
                        }
                    case '5':                           // clear the list of tasks
                        {
                            FileService.RemoveAllTasks();
                            break;
                        }
                    case '6':                           // the exit from the program
                        {
                            Console.WriteLine("EXIT");
                            break;
                        }
                    default:                            // default action when user choose different number than 1 to 6
                        {
                            Console.WriteLine("Choose correct number.");
                            break;
                        }
                }
            }
            while (choice != '6');                      // '6' is the exit sign and it is an exit condition from the switch
            #endregion
            Console.ReadLine();                         // prevent auto close the console window
        }
    }
}
