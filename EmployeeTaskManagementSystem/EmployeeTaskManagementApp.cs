using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmployeeTaskManagementSystem.Enums;

namespace EmployeeTaskManagementSystem
{
    public static class EmployeeTaskManagementApp
    {
        public static void RunMenu()//запускає меню
        {
            UserManagerSingleton userManager = UserManagerSingleton.GetInstance();
            TaskManagerSingleton taskManager = TaskManagerSingleton.GetInstance();
            int choice = -1;
            while (choice != 0)
            {
                Console.Clear();
                ShowMenu();
                ChooseTask(GetId("number of task"));
            }
        }
        public static void ChooseTask(int choice)
        {
            switch (choice)
            {
                case 0:
                    return;
                case 1:
                    InitializeTask();
                    Console.ReadLine();
                    break;
                case 2:
                    InitializeUser();
                    Console.ReadLine();
                    break;
                case 3:
                    UserManagerSingleton.GetInstance().GetUser(GetString("name of user")).AssignTask(TaskManagerSingleton.GetInstance().GetTask(GetString("title of task")));
                    Console.ReadLine();
                    break;
                case 4:
                    UserManagerSingleton.GetInstance().RemoveUser(GetString("name of user"));
                    Console.ReadLine();
                    break;
                case 5:
                    TaskManagerSingleton.GetInstance().RemoveTask(GetString("title of task"));
                    Console.ReadLine();
                    break;
                case 6:
                    TaskManagerSingleton.GetInstance().GetActiveTasks();
                    
                    Console.ReadLine();
                    break;
                case 7:
                    TaskManagerSingleton.GetInstance().GetTask(GetString("title of task")).ChangeStatus(GetTaskValue<Enums.TaskStatus>("Choose task status"));
                    Console.ReadLine();
                    break;
                case 8:
                    foreach (var item in TaskManagerSingleton.GetInstance().Tasks)
                    {
                        Console.WriteLine(item);
                    }
                    Console.ReadLine();
                    break;
                case 9:
                    foreach (var item in UserManagerSingleton.GetInstance().Users)
                    {
                        Console.WriteLine(item);
                    }
                    Console.ReadLine();
                    break;
            }

        }
        public static void ShowMenu()
        {
            Console.WriteLine
               ("1.Add task." +
                "\n2.Add user" +
                "\n3.Assign task to user" +
                "\n4.Remove user." +
                "\n5.Remove task." +
                "\n6.Show active tasks(New and in progress)" +
                "\n7.Change status of task" +
                "\n8.Show all tasks" +
                "\n9.Show all users");

        }
        public static void InitializeTask()
        {
            TaskManagerSingleton.GetInstance().AddTask(new Task(GetId("Id"), GetString("Title"), GetTaskValue<Enums.TaskType>("Choose task type"), GetTaskValue<Enums.TaskPriority>("Choose task priority"), GetTaskValue<Enums.TaskStatus>("Choose task status"), GetTaskAttributes()));
        }

        public static void InitializeUser()
        {
            UserManagerSingleton.GetInstance().AddUser(GetString("Name"), GetString("Role"));
        }
        public static int GetId(string paramName)
        {
            int Id = 0;

            Console.WriteLine($"Input {paramName}");

            while (!int.TryParse(Console.ReadLine(), out Id))
            {
                Console.WriteLine("Input correct data");
            }

            return Id;
        }
        public static string GetString(string paramName)
        {
            return InputString(paramName);
        }
        public static T GetTaskValue<T>(string description) where T : Enum
        {

            ShowEnumValues<T>();

            int choice = InputEnumValue(Enum.GetValues(typeof(T)).Length,description);

            return Enum.GetValues(typeof(T)).Cast<T>().ToArray()[choice - 1];
        }

        public static Enums.TaskAttributes GetTaskAttributes()
        {
            Console.WriteLine("Select task attributes (you can select multiple by separating with commas):");
            ShowEnumValues<TaskAttributes>();

            string[] selectedNumbers = GetString("the corresponding numbers").Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Enums.TaskAttributes result = TaskAttributes.None;

            foreach (string number in selectedNumbers)
            {
                if (int.TryParse(number, out int value))
                {
                    var enumValues = Enum.GetValues(typeof(TaskAttributes)).Cast<TaskAttributes>().ToArray();
                    if (value >= 1 && value <= enumValues.Length)
                    {
                        result |= enumValues[value - 1];
                    }
                    else
                    {
                        Console.WriteLine($"Invalid option: {value}");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid input: {number}");
                }
            }

            return result;
        }

        public static void ShowEnumValues<T>() where T : Enum
        {
            Console.Clear();
            var values = Enum.GetValues(typeof(T)).Cast<T>().ToArray();

            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {values[i]}");
            }
        }
        public static int InputEnumValue(int maxLength,string description)
        {
            int choice;
            Console.WriteLine(description);
            Console.WriteLine("Enter the corresponding number:");

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > maxLength)
            {
                Console.WriteLine("Invalid choice. Please enter a valid number:");
            }

            return choice;
        }
        public static string InputString(string input)
        {
            string Temp = string.Empty;

            Console.WriteLine($"Input {input}:");

            while (Temp == string.Empty)
            {
                Temp = Console.ReadLine();
            }

            return Temp;
        }

    }
}
