using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskManagementSystem
{
    public class Enums
    {
        public enum TaskStatus   //Використовується для відображення поточного стану завдання.
        {
            None,
            New = 1,
            InProgress,
            Completed,
            Cancelled
        }

        public enum TaskType    //Використовується для класифікації завдань
        {
            Development,
            Testing,
            Documentation
        }

        public enum TaskPriority  //Використовується для позначення пріоритету завдання.
        {
            Low,
            Medium,
            High
        }

        [Flags]
        public enum TaskAttributes   //Використовується для додаткової характеристики завдання
        {
            None = 0,
            Urgent = 1,
            RequiresReview = 2,
            HighRisk = 4,
            ClientVisible = 8
        }

        public enum UserRole   //Використовується для опису ролі користувача
        {
            Developer,
            QAEngineer
        }
    }
}
