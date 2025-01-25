using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskManagementSystem
{
    internal class TaskManagerSingleton : TaskManager
    {
        public Task[] Tasks
        {
            get
            {
                return tasks;
            }
            set
            {
                tasks = value;
            }
        }

        int size;
        int position = -1;
        static TaskManagerSingleton instance = null;

        public override void AddTask(Task task)
        {
            EnsureCapacity();
            Tasks[size++] = task;
            //Task[] newTasks = new Task[Tasks.Length + 1];

            //for (int i = 0; i < Tasks.Length; i++)
            //{
            //    newTasks[i] = Tasks[i];
            //}

            //size = newTasks.Length;
            //newTasks[Tasks.Length] = task;
            //Tasks = newTasks;
        }

        public Task GetTask(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));

            var temp = Tasks.FirstOrDefault(t => t.Title == title);

            if (temp == null)
                throw new ArgumentException();

            return temp;

        }

        private Task GetTask(int id)
        {
            //if (id == null)
            //    throw new ArgumentNullException(nameof(id));

            var temp = Tasks.FirstOrDefault(t => t.Id == id);

            if (temp == null)
                throw new ArgumentException();

            return temp;

        }

        private Task GetTask(Task task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            var temp = Tasks.FirstOrDefault(t => t.Equals(task));

            if (temp == null)
                throw new ArgumentException();

            return temp;

        }

        public override void RemoveTask(Task task)
        {
            RemoveTaskAt(IndexOf(GetTask(task)));
            //Task[] newTasks = new Task[Tasks.Length - 1];

            //for (int i = 0; i < newTasks.Length; i++)
            //{
            //    if (Tasks[i] != task)
            //    {
            //        newTasks[i] = Tasks[i];
            //    }
            //}

            //size = newTasks.Length;
            //Tasks = newTasks;
        }
        public void RemoveTask(string title)
        {
            RemoveTaskAt(IndexOf(GetTask(title)));
        }

        public bool MoveNext()
        {
            if (position < Tasks.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                Reset();
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }

        public Object Current
        {
            get
            {
                return Tasks[position];
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                yield return Tasks[i];
            }
        }
        private void RemoveTaskAt(int index)
        {
            if ((uint)index >= (uint)size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            --size;

            if (index < size)
            {
                Array.Copy(Tasks, index + 1, Tasks, index, size - index);
            }

            Tasks[size] = null;
        }

        public IEnumerable<Task> GetTasksByAssignee(string name)
        {
            for (int i = 0; i < size; i++)
            {
                if (Tasks[i].Asignee.Name == name)
                    yield return Tasks[i];
            }
        }

        public IEnumerable<Task> GetTasksByAssignee(User user)
        {
            for (int i = 0; i < size; i++)
            {
                if (Tasks[i].Asignee == user)
                    yield return Tasks[i];
            }
        }
        public void NullAsignee(string name)
        {
            foreach (var task in GetTasksByAssignee(name))
            {
                task.Asignee = null;
            }
            //for (int i = 0; i < size; i++)
            //{
            //    if (Tasks[i].Asignee.Name == name)
            //        Tasks[i].Asignee = null;
            //}
        }

        public void RemoveTask(int id)
        {

            RemoveTaskAt(IndexOf(GetTask(id)));
            //if ((uint)index>=(uint)size)
            //{
            //    throw new ArgumentOutOfRangeException("index");
            //}
            //--size;
            //if (index < size)
            //{
            //    Array.Copy(Tasks,index+1,Tasks,index,size-index);                                                                       
            //}
            //Tasks[size] = null;
        }

        private int IndexOf(Task task)
        {
            return Array.IndexOf(Tasks, task, 0, size);
        }

        private void EnsureCapacity()
        {
            if (size == Tasks.Length)
            {
                int newCapacity = Tasks.Length == 0 ? 4 : Tasks.Length * 2;

                Task[] temp = new Task[newCapacity];

                Array.Copy(Tasks, temp, Tasks.Length);

                Tasks = temp;
            }
        }

        public override void GetActiveTasks()
        {
            //int activeTasksNumber = 0;

            for (int i = 0; i < Tasks.Length; i++)
            {
                if (Tasks[i] != null)
                {
                    if (Tasks[i].Status == Enums.TaskStatus.New || Tasks[i].Status == Enums.TaskStatus.InProgress)
                    {
                        //activeTasksNumber++;
                        Console.WriteLine(Tasks[i].ToString());
                    }
                }
                Console.WriteLine();
            }

            //Task[] activeTasks = new Task[activeTasksNumber];
            //int temp = 0;

            //for (int i = 0; i < Tasks.Length; i++)
            //{
            //    if (Tasks[i].Status == "New" || Tasks[i].Status == "InProgress")
            //    {
            //        activeTasks[temp] = Tasks[i];
            //        temp++;
            //    }
            //}
        }
        protected TaskManagerSingleton()
        {
            Tasks = Array.Empty<Task>();
            size = 0;
        }
        public static TaskManagerSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new TaskManagerSingleton();
            }

            return instance;
        }
    }
}
