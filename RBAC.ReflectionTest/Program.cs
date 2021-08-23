using System;
using System.Reflection;

namespace RBAC.ReflectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Student);

            foreach (var item in type.GetProperties())
            {
                Console.WriteLine(item.Name);
            }

            Console.ReadLine();
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
