using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
                customerName= "_";
            var cacheData = _cache.Get(customerName);
            if (cacheData != null)
                return (List<Customer>)cacheData;

            var result = _dataAccess.GetCustomers(customerName);
            await Task.Delay(millisecondsDelay: 3000);

            _cache.Add(customerName, result);

            return result;
        }

        public void InsertCustomers(IEnumerable<CustomerData> customers)
        {
            _dataAccess.InsertCustomers(customers);
            _cache.Remove();
        }

        public void UpdateCustomers(IEnumerable<Customer> customers)
        {
            _dataAccess.UpdateCustomers(customers);
            _cache.Remove();
        }

        public void DeleteCustomers(IEnumerable<long> customerIds)
        {
            _dataAccess.DeleteCustomers(customerIds);
            _cache.Remove();
        }
    }
}