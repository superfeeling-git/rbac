using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using Dapper;

namespace RBAC.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            using (MySqlConnection conn = new MySqlConnection(""))
            {
                conn.Query("");
            }
            return View();
        }
    }
}
