using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movolytics.Models
{
    public class DataRepository : IDataRepository
    {
        private CustomerContext _customerContext;

        public DataRepository(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            IEnumerable<Customer> model = _customerContext.Customer
                .OrderByDescending(c => c.JoiningDate)
                .ToList<Customer>();
            return model;
        }

        public IEnumerable<Customer> GetCustomersJoiningAfter(DateTime dateFilter)
        {
            IEnumerable<Customer> model = _customerContext.Customer
                .Where(c => c.JoiningDate >= dateFilter)
                .OrderByDescending(c => c.JoiningDate)
                .ToList<Customer>();
            return model;
        }
    }
}
