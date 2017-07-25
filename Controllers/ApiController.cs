using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movolytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movolytics.Controllers
{
    [Route("/api/customer")]
    public class CustomerController : Controller
    {
        private IDataRepository _repository;
        private ILogger<CustomerController> _logger;

        public CustomerController(IDataRepository repository, ILogger<CustomerController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("joiningafter")]
        public IActionResult GetJoiningAfter(DateTime date)
        {
            try
            {
                var model = _repository.GetCustomersJoiningAfter(date);
                return Ok(model);
            }
            catch (Exception e)
            {
                _logger.LogError($"error in GetJoiningAfter(DateTime date): {e.Message}");
                return BadRequest($"error in /api/customer/joiningafter");
            }
        }
    }
}
