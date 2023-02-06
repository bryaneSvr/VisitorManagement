using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using VisitorManagement.Data;
using VisitorManagement.Data.Services;
using VisitorManagement.Models;

namespace VisitorManagement.Controllers
{
    /// <summary>
    /// Welcome to visitor management system
    /// </summary>
    public class CustomerController : ApiController
    {

        private ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets the list of all customers in the DB
        /// </summary>
        /// <returns>list of all customers</returns>
        // GET: api/Customer
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _service.GetCustomers(string.Empty);
        }

        /// <summary>
        /// Gets the list of customers with similar input name
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        // GET: api/Customer/CustomerName
        public async Task<IEnumerable<Customer>> Get(string customerName)
        {
            return await _service.GetCustomers(customerName);
        }

        /// <summary>
        /// Insert a new customer into the DB
        /// </summary>
        /// <param name="customers"></param>
        // POST: api/Customer
        public string Post([FromBody] IEnumerable<CustomerData> customers)
        {
            return _service.InsertCustomers(customers);
        }

        /// <summary>
        /// Update Existing customer with provided customer Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT: api/Customer/5
        public string Put([FromBody] IEnumerable<Customer> customers)
        {
            return _service.UpdateCustomers(customers);
        }

        /// <summary>
        /// Delete a paticular customer
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/Customer/5
        public string Delete(IEnumerable<long> customerIds)
        {
            return _service.DeleteCustomers(customerIds);
        }
    }
}
