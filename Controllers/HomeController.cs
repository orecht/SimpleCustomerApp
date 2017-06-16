using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Configuration;

using Movolytics.Models;

namespace Movolytics.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _config { get; set; }

        public HomeController(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult GetCustomersJoiningAfter()
        {
            using (var context = new CustomerContext(_config))
            {
                IEnumerable<Customer> model = context.Customer
                    .Where(c => c.JoiningDate >= new DateTime(2016, 02, 15))
                    .OrderByDescending(c => c.JoiningDate)
                    .ToList<Customer>();
                return View(model);
            }
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
