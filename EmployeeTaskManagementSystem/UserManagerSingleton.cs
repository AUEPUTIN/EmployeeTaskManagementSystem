using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeeTaskManagementSystem
{
    internal class UserManagerSingleton : IEnumerator,IEnumerable
    {
        public User[] Users { get; set; }
        int size;
        int position = -1;
        static UserManagerSingleton instance = null;

        public bool MoveNext()
        {
            if (position < Users.Length - 1)
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
            get { return Users[position]; }
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                yield return Users[i];
            }
        }
        public void AddUser(string name, string role)
        {
            EnsureCapacity();
            Users[size++] = new User(name, role);
        }

        private void EnsureCapacity()
        {
            if (size == Users.Length)
            {
                int newCapacity = Users.Length == 0 ? 4 : Users.Length * 2;
                User[] temp = new User[newCapacity];
                Array.Copy(Users, temp, Users.Length);
                Users = temp;
            }
        }

        public User GetUser(string name)
        {
            if (name == null)
                throw new ArgumentException();

            var temp = Users.FirstOrDefault(x => x.Name == name);
            
            if (temp == null)
                throw new ArgumentException(nameof(name));

            return temp;
        }



        private User GetUser(User user)
        {
            if (user == null)
                throw new ArgumentException();

            var temp = Users.FirstOrDefault(x => x.Equals(user));
            
            if (temp == null)
                throw new ArgumentException();

            return temp;
        }

        public void RemoveUser(string name)
        {
            TaskManagerSingleton.GetInstance().NullAsignee(name); //присвоюємо полю виконавець nulll
            RemoveUserAt(IndexOf(GetUser(name)));
            
        }
        public void RemoveUser(User user)
        {
            TaskManagerSingleton.GetInstance().NullAsignee(user.Name); //присвоюємо полю виконавець nulll
            RemoveUserAt(IndexOf(GetUser(user)));
        }

        private void RemoveUserAt(int index)
        {
            if ((uint)index >= (uint)size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            --size;

            if (index < size)
            {
                
                Array.Copy(Users, index + 1, Users, index, size - index);
            }

            Users[size] = null;
        }

        private int IndexOf(User user)
        {
            return Array.IndexOf(Users, user, 0, size);
        }
        protected UserManagerSingleton()
        {
            Users = new User[0];
            size = 0;
        }

        public static UserManagerSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new UserManagerSingleton();
            }
            return instance;
        }
    }
}
