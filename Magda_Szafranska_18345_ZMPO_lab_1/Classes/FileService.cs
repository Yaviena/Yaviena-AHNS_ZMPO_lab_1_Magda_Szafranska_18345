using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ToDoList_MagdaSzafranska
{
    /// <summary>
    /// A class to operate files (saving to the file)
    /// </summary>
    internal class FileService
    {
        public static int CounterOfTasksInFile = 0; // a helper variable keeping number of all tasks (using to removing single task)
        private static string[] listOfTasks;        // a list keeping all read tasks
        private static StreamWriter stream_write;   // a private variable to write data in the file
        private static StreamReader stream_read;    // a private variable to read data in the file

        public static void SaveTask(Task task)      // save task appending it to the end of the file
        {
            stream_write = new StreamWriter(TaskBase.filePath, append: true, Encoding.ASCII);
            try
            {
                if (!File.Exists(TaskBase.filePath))        // check if file exist; if not - create in the right pah
                {
                    File.Create(TaskBase.filePath);
                    Console.WriteLine("File has been created on the disc.");
                }

                if (task.TaskName != String.Empty)
                {
                    stream_write.WriteLine(task.TaskName);
                }
            }
            catch (IOException ex)                          // catch exceptions when file does not work correctly
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            stream_write.Close();                           // closing the file
        }
        public static void ReadTasks()              // read all tasks from the file and save them to the array
        {
            if (IsFileExist() == true)
            {
                stream_read = new StreamReader(TaskBase.filePath, Encoding.ASCII);
                listOfTasks = File.ReadAllLines(TaskBase.filePath);
                stream_read.Close();
            }
            else
            {
                Console.WriteLine("The file is not existing yet");
            }
        }
        public static void ShowTasksFromFile()      // show all tasks saved in the file
        {
            if (IsFileExist() == true)
            {
                ReadTasks();
                if (listOfTasks.Length == 0)
                {
                    Console.WriteLine("Free up your mind space and add some tasks!");
                }
                else
                {
                    for (int i = 0; i < listOfTasks.Length; i++)
                    {
                        Console.WriteLine($"TASK {i + 1}: {listOfTasks[i]}");
                    }
                }
            }
            else
            {
                Console.WriteLine("The list is empty. Free up your mind space and add some tasks!");
            }
        }
        public static void ShowFromTheNewest()      // show all tasks from the newest to the older order
        {
            if (IsFileExist() == true)
            {
                ReadTasks();
                if (listOfTasks.Length == 0)
                {
                    Console.WriteLine("Free up your mind space and add some tasks!");
                }
                else
                {
                    for (int i = listOfTasks.Length - 1, k = 1; i >= 0; i--, k++)
                    {
                        Console.WriteLine($"TASK {k}: {listOfTasks[i]}");
                    }
                }
            }
            else
            {
                Console.WriteLine("The list is empty. Free up your mind space and add some tasks!");
            }
        }
        public static void RemoveOneTask()          // remove one task choosen by the user
        {
            if (IsFileExist() == true && listOfTasks != null && listOfTasks.Length != 0 && listOfTasks[0] != "")
            {
                ShowTasksFromFile();
                try
                {
                    Console.Write("Choose the number of task you want to remove: ");
                    int TaskNrToRemove = Convert.ToInt32(Console.ReadLine());

                    for (int i = TaskNrToRemove - 1; i < listOfTasks.Length - 1; i++)
                    {
                        listOfTasks[i] = listOfTasks[i + 1];
                    }
                    Array.Resize(ref listOfTasks, listOfTasks.Length - 1);
                    Console.WriteLine("The task of indeks {0} has been deleted.", TaskNrToRemove);
                    TaskBase.CurrentTaskNumber--;

                    // save new listOfTasks without deleted task member
                    File.WriteAllText(TaskBase.filePath, String.Empty);

                    StreamWriter stream_write2 = new StreamWriter(TaskBase.filePath, append: true, Encoding.ASCII);
                    for (int i = 0; i < listOfTasks.Length; i++)
                    {
                        stream_write2.WriteLine(listOfTasks[i]);
                    }
                    stream_write2.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Free up your mind space and add some tasks!");
            }
        }
        public static void RemoveAllTasks()         // remove all tasks from the list
        {
            if (IsFileExist() == true && listOfTasks != null)
            {
                ReadTasks();
                try
                {
                    Array.Clear(listOfTasks, 0, listOfTasks.Length);
                    File.WriteAllText(TaskBase.filePath, String.Empty);
                    Console.WriteLine("The list is clear");
                    CounterOfTasksInFile = 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Free up your mind space and add some tasks!");
            }
        }
        private static bool IsFileExist()           // check if the file is created in the directory
        {
            try
            {
                if (!File.Exists(TaskBase.filePath))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
