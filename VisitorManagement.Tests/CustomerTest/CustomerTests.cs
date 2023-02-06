using Autofac.Extras.Moq;
using VisitorManagement.Data.Services;
using Xunit;
using VisitorManagement.Data;
using VisitorManagement.Data.Caching;
using System.Linq;

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
                    .Setup(x => x.GetCustomers(string.Empty))
                    .Returns(CustomerDataSetup.Customers);

                mock.Mock<ICache>()
                    .Setup(x=>x.Get(GetMessage.DefaultGetKey()))
                    .Returns(CustomerDataSetup.Customers);

                var cls = mock.Create<CustomerService>();

                var expected = CustomerDataSetup.Customers;
                var actual = cls.GetCustomers(string.Empty);

                Assert.True(actual.Result != null);
                Assert.Equal(expected.Count , actual.Result.Count);
            }
        }

        [Fact]
        public void InsertCustomers_Test()
        {
            var records = CustomerDataSetup.CustomerData.Count().ToString();
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IDataAccess>()
                    .Setup(x => x.InsertCustomers(CustomerDataSetup.CustomerData))
                    .Returns(records);

                var cls = mock.Create<CustomerService>();

                var expected = GetMessage.Inserted(records);
                var actual = cls.InsertCustomers(CustomerDataSetup.CustomerData);

                Assert.Equal(actual, expected);
            }
        }

        [Fact]
        public void UpdateCustomers_Test()
        {
            var records = CustomerDataSetup.Customers.Count().ToString();

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IDataAccess>()
                    .Setup(x => x.UpdateCustomers(CustomerDataSetup.Customers))
                    .Returns("1");

                var cls = mock.Create<CustomerService>();

                var expected = GetMessage.Updated(records);
                var actual = cls.UpdateCustomers(CustomerDataSetup.Customers);

                Assert.Equal(actual, expected);
            }
        }

        [Fact]
        public void DeleteCustomers_Test()
        {
            var records = CustomerDataSetup.CustomerIds.Count().ToString();

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IDataAccess>()
                    .Setup(x => x.DeleteCustomers(CustomerDataSetup.CustomerIds))
                    .Returns(CustomerDataSetup.CustomerIds.Count().ToString());

                var cls = mock.Create<CustomerService>();

                var expected = GetMessage.Deleted(records);
                var actual = cls.DeleteCustomers(CustomerDataSetup.CustomerIds);

                Assert.Equal(actual, expected);
            }
        }
    }
}
