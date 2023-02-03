using System.Collections.Generic;
using System.Threading.Tasks;
using VisitorManagement.Models;

namespace VisitorManagement.Data.Services
{
    public interface ICustomerService
    {
        void DeleteCustomers(IEnumerable<long> customerIds);
        Task<List<Customer>> GetCustomers(string customerName);
        void InsertCustomers(IEnumerable<CustomerData> customers);
        void UpdateCustomers(IEnumerable<Customer> customers);
    }
}
