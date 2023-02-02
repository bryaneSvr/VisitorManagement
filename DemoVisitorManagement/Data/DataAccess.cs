using VisitorManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using DemoVisitorManagement.Data;
using Dapper;

namespace VisitorManagement.Data
{
    public class DataAccess
    {
        public List<Customer> GetCustomers(string customerName)
        {
            if (string.IsNullOrEmpty(customerName))
                customerName = string.Empty;
            using (IDbConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString("VisitorRepository")))
            {
                var customers = connection.Query<Customer>("dbo.GetCustomers @CustomerName", new { CustomerName = customerName}).ToList();

                return customers;
            }
        }
    }
}