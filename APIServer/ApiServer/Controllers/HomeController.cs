using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ApiServer.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration Configuration;
        public HomeController(IConfiguration configuration) {
            Configuration = configuration;
        }
        public IActionResult Index()
        {
            string connString = this.Configuration.GetConnectionString("DbConnection");
            return View();
        }
    }
}
