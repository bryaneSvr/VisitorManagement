using System.Collections.Generic;
using System.Web.Http;
using VisitorManagement.Data;
using VisitorManagement.Models;

namespace DemoVisitorManagement.Controllers
{
    public class CustomerController : ApiController
    {
        DataAccess db = new DataAccess();

        // GET: api/Customer
        public IEnumerable<Customer> Get()
        {
            return db.GetCustomers( string.Empty);
        }

        // GET: api/Customer/CustomerName
        public IEnumerable<Customer> Get(string customerName)
        {
            return db.GetCustomers(customerName);
        }

        // POST: api/Customer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
