using System.Collections.Generic;
using System.Threading.Tasks;
using VisitorManagement.Models;

namespace VisitorManagement.Data.Services
{
    public interface ICustomerService
    {
        string DeleteCustomers(IEnumerable<long> customerIds);
        Task<List<Customer>> GetCustomers(string customerName);
        string InsertCustomers(IEnumerable<CustomerData> customers);
        string UpdateCustomers(IEnumerable<Customer> customers);
    }
}
