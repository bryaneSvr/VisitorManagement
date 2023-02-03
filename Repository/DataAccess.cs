﻿using VisitorManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using VisitorManagement.Data.Services;

namespace VisitorManagement.Data
{
    public class DataAccess : IDataAccess
    {
        public DataAccess()
        {

        }
        public List<Customer> GetCustomers(string customerName)
        {
            if (string.IsNullOrEmpty(customerName))
                customerName = string.Empty;
            using (IDbConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                var customers = connection.Query<Customer>("dbo.GetCustomers @CustomerName", new { CustomerName = customerName }).ToList();

                return customers;
            }
        }

        public void InsertCustomers(IEnumerable<CustomerData> customers)
        {
            if (!customers.Any()) { return; }

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add(new DataColumn("CustomerName", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Address", typeof(string)));
            dataTable.Columns.Add(new DataColumn("ContactNumber", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Country", typeof(string)));

            foreach (var customer in customers)
            {
                var row = dataTable.NewRow();
                row["CustomerName"] = customer.CustomerName;
                row["Address"] = customer.Address;
                row["ContactNumber"] = customer.ContactNumber;
                row["Country"] = customer.Country;
                dataTable.Rows.Add(row);
            }

            using (IDbConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                var storedProcedure = "dbo.InsertCustomer";
                connection.Query(storedProcedure, new { Customers = dataTable }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}