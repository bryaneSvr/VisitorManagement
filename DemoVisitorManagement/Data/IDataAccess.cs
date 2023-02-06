using System.Collections.Generic;
using VisitorManagement.Models;

namespace VisitorManagement.Data
{
    public interface IDataAccess
    {
        List<Customer> GetCustomers(string customerName);
        string InsertCustomers(IEnumerable<CustomerData> customers);
        string UpdateCustomers(IEnumerable<Customer> customers);
        string DeleteCustomers(IEnumerable<long> customerIds);
    }
}