using EmployeeTaskManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//oВластивості:
//Name: Ім'я користувача.
//Role: Роль користувача(наприклад, Developer, QA Engineer).
//oМетоди:
//AssignTask(Task task): Призначає завдання користувачу.

namespace EmployeeTaskManagementSystem
{
    internal interface IUser
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public void AssignTask(Task task);
    }
}
