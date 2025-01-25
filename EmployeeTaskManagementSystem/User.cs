using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskManagementSystem
{
    internal class User(string name, string role) : IUser
    {
        public string Name { get; set; } = name;
        public string Role { get; set; } = role;
        public void AssignTask(Task task)
        {
            task.Asignee = this;
        }
        public override string ToString()
        {
            return $"Name: {Name}\nRole: {Role}";
        }
    }
}
