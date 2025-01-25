using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskManagementSystem
{
    abstract class TaskManager
    {
        protected Task[] tasks;
        public abstract void AddTask(Task task);
        public abstract void RemoveTask(Task task);
        public abstract void GetActiveTasks();
    }
}
