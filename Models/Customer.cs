using System;
using System.Collections.Generic;

namespace Movolytics.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}
