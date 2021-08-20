using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace RBAC.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            using (MySqlConnection conn = new MySqlConnection(""))
            {
                
            }
            return View();
        }
    }
}
