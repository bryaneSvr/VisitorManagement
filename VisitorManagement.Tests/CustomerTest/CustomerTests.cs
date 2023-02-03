using Autofac.Extras.Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorManagement.Models;
using VisitorManagement.Data.Services;
using Xunit;
using VisitorManagement.Controllers;
using VisitorManagement.Data;
using VisitorManagement.Data.Caching;

namespace VisitorManagement.Tests.CustomerTest
{
    public class CustomerTests
    {
        [Fact]
        public void GetCustomers_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IDataAccess>()
                    .Setup(x => x.GetCustomers(""))
                    .Returns(MockCustomers);

                mock.Mock<ICache>()
                    .Setup(x=>x.Get("_"))
                    .Returns(MockCustomers);

                var cls = mock.Create<CustomerService>();

                var expected = MockCustomers();
                var actual = cls.GetCustomers("");

                Assert.True(actual.Result != null);
                Assert.Equal(expected.Count , actual.Result.Count);
            }
        }

        [Fact]
        public void InsertCustomers_Test()
        {
            List<CustomerData> customerData = new List<CustomerData>();
            customerData.Add(new CustomerData
            {
                Address = "123"
                ,
                CustomerName = "123"
            });
            using (var mock = AutoMock.GetLoose())
            {
                var cls = mock.Create<CustomerService>();

                var expected = MockCustomers();
                cls.InsertCustomers(customerData);

                Assert.True(customerData.Count == 1);
            }
        }

        private List<Customer> MockCustomers()
        {
            List < Customer > customers = new List < Customer > ();
            customers.Add(new Customer
            {
                Address = "123"
                ,
                CustomerName = "123"
            });
            return customers;
        }


        private List<CustomerData> MockCustomerData()
        {
            List<CustomerData> customers = new List<CustomerData>();
            customers.Add(new CustomerData
            {
                Address = "123"
                ,
                CustomerName = "123"
            });
            return customers;
        }
    }
}
