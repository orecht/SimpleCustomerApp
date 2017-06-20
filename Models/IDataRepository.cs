using System;
using System.Collections.Generic;

namespace Movolytics.Models
{
    public interface IDataRepository
    {
        IEnumerable<Customer> GetCustomersJoiningAfter(DateTime dateFilter);
    }
}