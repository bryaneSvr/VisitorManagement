using System.Collections.Generic;
using VisitorManagement.Data;
using VisitorManagement.Models;

namespace VisitorManagement.Tests.CustomerTest
{
    public static class CustomerDataSetup
    {
        public static List<Customer> Customers = new List<Customer>()
        {
            new Customer
            {
                Address = "123",
                CustomerName = "123"
            } 
        };


        public static List<CustomerData> CustomerData = new List<CustomerData>() 
        {
            new CustomerData
            {
                Address = "123",
                CustomerName = "123"
            }
        };

        public static IEnumerable<long> CustomerIds = new long[] { 1, 2 };
    }
}
