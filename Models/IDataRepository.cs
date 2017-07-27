using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Movolytics.Models
{
    public interface IDataRepository
    {
        IEnumerable<Customer> GetCustomers();
        IEnumerable<Customer> GetCustomersJoiningAfter(DateTime dateFilter);
    }
}