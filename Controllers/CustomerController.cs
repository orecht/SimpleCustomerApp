using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movolytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movolytics.Controllers
{
//    [Route("/api/customers")]
    public class CustomerController : Controller
    {
        private IDataRepository _repository;
        private ILogger<CustomerController> _logger;

        public CustomerController(IDataRepository repository, ILogger<CustomerController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("/api/customers")]
        public IActionResult Get([FromQuery] string joinedafterdate)
        {
            try
            {
                IEnumerable<Customer> model = null;
                if (String.IsNullOrEmpty(joinedafterdate))
                {
                    model = _repository.GetCustomers();
                }
                else
                {
                    var date = DateTime.Parse(joinedafterdate);
                    model = _repository.GetCustomersJoiningAfter(date);
                }

                return Ok(model);
            }
            catch (Exception e)
            {
                _logger.LogError($"error in Get(DateTime joinedafterdate): {e.Message}");
                return BadRequest($"error in /api/customers");
            }
        }
    }
}
