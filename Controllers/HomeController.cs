using Microsoft.AspNetCore.Mvc;

using Movolytics.Models;

namespace Movolytics.Controllers
{
    public class HomeController : Controller
    {
        private IDataRepository _repository;

        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
