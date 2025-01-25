using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmployeeTaskManagementSystem.Enums;

//Використовується для зберігання інформації про завдання.

namespace EmployeeTaskManagementSystem
{
    internal record Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Enums.TaskType Type { get; set; }
        public Enums.TaskPriority Priority { get; set; }
        public Enums.TaskStatus Status { get; set; }
        public Enums.TaskAttributes Attributes { get; set; }
        public User Asignee { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}\nTitle: { Title}\nType: {Type}\nPriority: {Priority}\nStatus: {Status}\nAttributes: {Extensions.ToDescription(Attributes)}\n Asignee: {Asignee?.Name ?? "No Asignee"} ";
        }
        public void ChangeStatus(Enums.TaskStatus newStatus)
        {
            Status = newStatus;
        }

        public Task(int id,string title,Enums.TaskType type,Enums.TaskPriority priority,Enums.TaskStatus status,Enums.TaskAttributes attributes)
        {
            Id = id;
            Title = title;
            Type = type;
            Priority = priority;
            Status = status;
            Attributes = attributes;
        }

    }
}
