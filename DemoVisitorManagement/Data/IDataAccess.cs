using System.Collections.Generic;
using VisitorManagement.Models;

namespace VisitorManagement.Data
{
    public interface IDataAccess
    {
        List<Customer> GetCustomers(string customerName);
        void InsertCustomers(IEnumerable<CustomerData> customers);
        void UpdateCustomers(IEnumerable<Customer> customers);
        void DeleteCustomers(IEnumerable<long> customerIds);
    }
}