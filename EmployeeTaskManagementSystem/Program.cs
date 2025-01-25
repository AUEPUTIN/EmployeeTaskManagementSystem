using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskManagementSystem
{
    internal class Program
    {
        static void Main()
        {
            Enums.TaskAttributes attributes = Enums.TaskAttributes.Urgent | Enums.TaskAttributes.RequiresReview;

            Console.WriteLine(attributes.ToDescription());
            EmployeeTaskManagementApp.RunMenu();
            //UserManagerSingleton userManager = UserManagerSingleton.GetInstance();
            //TaskManagerSingleton taskManager = TaskManagerSingleton.GetInstance();

            ////Task task1 = new Task(1, "Testing new API", Enums.TaskType.Testing, Enums.TaskPriority.High, Enums.TaskStatus.New, Enums.TaskAttributes.Urgent | Enums.TaskAttributes.RequiresReview);
            ////Task task2 = new Task(2, "Development of a new module", Enums.TaskType.Development, Enums.TaskPriority.Medium, Enums.TaskStatus.New, Enums.TaskAttributes.ClientVisible);
            ////Task task3 = new Task(3, "Documenting changes", Enums.TaskType.Documentation, Enums.TaskPriority.Low, Enums.TaskStatus.New, Enums.TaskAttributes.None);

            
            //taskManager.AddTask(new Task(1, "Testing new API", Enums.TaskType.Testing, Enums.TaskPriority.High, Enums.TaskStatus.New, Enums.TaskAttributes.Urgent | Enums.TaskAttributes.RequiresReview));
            //taskManager.AddTask(new Task(2, "Development of a new module", Enums.TaskType.Development, Enums.TaskPriority.Medium, Enums.TaskStatus.New, Enums.TaskAttributes.ClientVisible));
            //taskManager.AddTask(new Task(3, "Documenting changes", Enums.TaskType.Documentation, Enums.TaskPriority.Low, Enums.TaskStatus.New, Enums.TaskAttributes.None));

            //userManager.AddUser("Mary", "QA Engineer");
            //userManager.AddUser("Andrew", "Developer");


            //UserManagerSingleton.GetInstance().GetUser("Mary").AssignTask(TaskManagerSingleton.GetInstance().Tasks[0]);
            //UserManagerSingleton.GetInstance().GetUser("Andrew").AssignTask(TaskManagerSingleton.GetInstance().Tasks[1]);

            //TaskManagerSingleton.GetInstance().Tasks[0].ChangeStatus(Enums.TaskStatus.InProgress);
            //TaskManagerSingleton.GetInstance().Tasks[0].ChangeStatus(Enums.TaskStatus.Completed);

            //TaskManagerSingleton.GetInstance().GetActiveTasks();

            Console.WriteLine();
        }
    }
}
