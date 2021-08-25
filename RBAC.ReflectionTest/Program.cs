using System;
using System.Collections.Generic;
using System.Reflection;
using RBAC.Model;

namespace RBAC.ReflectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //runtime
            //栈  treelist  指针
            //托管堆  分配内存
            int a = 3;
            List<treemodel> treelist = new List<treemodel>();
            treelist.Add(new treemodel { id = 1, title = "河北省" });

            Console.ReadLine();
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
