using Microsoft.AspNetCore.Mvc;

using SimpleCustomerApp.Models;

namespace SimpleCustomerApp.Controllers
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
