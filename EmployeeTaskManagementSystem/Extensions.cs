using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmployeeTaskManagementSystem.Enums;

namespace EmployeeTaskManagementSystem
{
    static class Extensions
    {
        public static string ToDescription(this Enums.TaskAttributes attributes)
        {

            if (attributes == Enums.TaskAttributes.None)
            {
                return "None";
            }

            var values = Enum.GetValues<Enums.TaskAttributes>().Cast<Enums.TaskAttributes>().Where(flag => flag != Enums.TaskAttributes.None && attributes.HasFlag(flag));

            return string.Join(" | ", values);
        }
        public static string ToReadableString(this Enums.TaskStatus taskStatus)
        {
            if (Enum.IsDefined(typeof(Enums.TaskStatus), taskStatus))
            {

                return taskStatus.ToString();
            }

            return Enums.TaskStatus.None.ToString();
        }
    }
}
