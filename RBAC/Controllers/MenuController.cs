using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace RBAC.Controllers
{
    public class MenuController : Controller
    {
        private IConfiguration configuration;

        public MenuController(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
