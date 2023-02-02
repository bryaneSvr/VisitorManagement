using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisitorManagement.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Country { get; set; }
    }
}