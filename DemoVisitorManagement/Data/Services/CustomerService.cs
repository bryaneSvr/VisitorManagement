using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorManagement.Data.Caching;
using VisitorManagement.Models;

namespace VisitorManagement.Data.Services
{
    public class CustomerService : ICustomerService
    {
        private IDataAccess _dataAccess;
        private ICache _cache;

        public CustomerService(IDataAccess dataAccess, ICache cache)
        {
            _dataAccess= dataAccess;
            _cache= cache;
        }

        public async Task<List<Customer>> GetCustomers(string customerName)
        {
            if(string.IsNullOrEmpty(customerName))
                customerName= Messages.DefaultGetKey;
            var cacheData = _cache.Get(customerName);
            if (cacheData != null)
                return (List<Customer>)cacheData;

            var result = _dataAccess.GetCustomers(customerName);
            await Task.Delay(millisecondsDelay: 3000);

            _cache.Add(customerName, result);

            return result;
        }

        public string InsertCustomers(IEnumerable<CustomerData> customers)
        {
            if (!customers.Any()) { return Messages.EmptyInput; }

            string data = _dataAccess.InsertCustomers(customers);
            _cache.Remove();

            string records = string.IsNullOrEmpty(data) ? Messages.OperationFailed : data;

            var result = GetMessage.Inserted(records);
            return result;
        }

        public string UpdateCustomers(IEnumerable<Customer> customers)
        {
            if (!customers.Any()) { return Messages.EmptyInput; }

            string data = _dataAccess.UpdateCustomers(customers);
            _cache.Remove();

            string records = string.IsNullOrEmpty(data) ? Messages.OperationFailed : data;

            var result = GetMessage.Updated(records);
            return result;
        }

        public string DeleteCustomers(IEnumerable<long> customerIds)
        {
            if (!customerIds.Any()) { return Messages.EmptyInput; }

            var data = _dataAccess.DeleteCustomers(customerIds);
            _cache.Remove();

            string records = string.IsNullOrEmpty(data) ? Messages.OperationFailed : data;

            var result = GetMessage.Deleted(records);
            return result;
        }
    }
}