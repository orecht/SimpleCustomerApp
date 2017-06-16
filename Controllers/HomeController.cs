using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Movolytics.Models;

namespace Movolytics.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (var context = new CustomerContext())
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
