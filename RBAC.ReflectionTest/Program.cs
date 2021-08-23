using System;
using System.Reflection;

namespace RBAC.ReflectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.ID = 1;
            student.Name = "张三";

            Type type = student.GetType();

            Console.WriteLine($"父类：{type.BaseType}");

            Console.WriteLine($"类名：{type.Name}");

            Console.WriteLine($"命令空间：{type.Namespace}");

            Console.WriteLine($"完整名称：{type.FullName}");

            Console.WriteLine($"程序集完整路径：{type.Assembly.Location}");


            foreach (var item in type.GetProperties())
            {
                //Console.WriteLine($"属性名:{item.Name},属性值:{item.GetValue(student)}");
                if(item.Name == "ID")
                {
                    item.SetValue(student, 2);
                }
                if (item.Name == "Name")
                {
                    item.SetValue(student, "李四");
                }
            }

            Console.WriteLine(student.Name);

            Console.ReadLine();
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
