using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Movolytics.Models;
using Microsoft.Extensions.Logging;

namespace Movolytics.Controllers
{
    public class HomeController : Controller
    {
        private IDataRepository _repository;

        public HomeController(IDataRepository repository, ILogger<HomeController> logger)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCustomersJoiningAfter15022016()
        {
            var model = _repository.GetCustomersJoiningAfter(new DateTime(2016, 02, 15));
            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
