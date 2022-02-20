using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_MagdaSzafranska
{
    #region enum members to declare in the next version of app
    /*
    enum:
        status:
            - Not started (default)
            - In progress
            - Done
        priority (colourful) - OPT:
            - High
            - Medium
            - Low
        data comming - OPT:
            - No data (default)
            - Today
            - Tomorrow
            - Upcomming
    */
    #endregion

    internal class Helpers
    {
        public static void Menu(TaskBase tb)                // Menu showed the user at the very beginning
        {
            tb.MenuColourChange();
            Console.WriteLine("\t----------------------------------------------");
            Console.WriteLine("\tCopyright by Magda Szafrańska, index nr: 18345");
            Console.WriteLine("\tAdvance methods of object oriented programming");
            Console.WriteLine("\tComputer science, AHNS, III term");
            Console.WriteLine("\tTODO TASK APPLICATION");
            Console.WriteLine("\t----------------------------------------------");
            Console.WriteLine("1 - Show ALL TODO tasks (from the older)");
            Console.WriteLine("2 - Show ALL TODO tasks (from the newest)");
            Console.WriteLine("3 - Add NEW task");
            Console.WriteLine("4 - Remove ONE task");
            Console.WriteLine("5 - Remove ALL tasks");
            Console.WriteLine("6 - EXIT");
            TaskBase.MenuColourBack();
        }
        public static char ChooseOption(TaskBase tb)        // Ask user to type in the number from the menu
        {
            char choice = '0';
            tb.MenuColourChange();                          // Change the menu colour
            Console.Write("\tChoose option (1-6) ... ");
            try
            {
                choice = Convert.ToChar(Console.ReadLine());
                Task.MenuColourBack();                      // Back to default font colour
            }
            catch
            {
                Task.MenuColourBack();                      // Back to default font colour
            }
            return choice;
        }
    }
    public enum TaskPriority                                // To add priority to the tasks in the next version of app
    {
        Low,
        Medium,
        Heigh
    }
}
