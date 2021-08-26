using System;
using System.Collections.Generic;
using System.Reflection;
using RBAC.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace RBAC.ReflectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string connstr = "server=localhost;user id=root;persistsecurityinfo=True;database=rbac;password=lp_lucky";

            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                menuModel menu = new menuModel();
                menu.MenuID = 9;
                conn.Execute("delete from menu where MenuID = @MenuID", menu);
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
