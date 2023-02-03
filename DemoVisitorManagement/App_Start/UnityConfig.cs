using System.Web.Http;
using Unity;
using Unity.WebApi;
using VisitorManagement.Data;
using VisitorManagement.Data.Caching;
using VisitorManagement.Data.Services;

namespace VisitorManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IDataAccess, DataAccess>();
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<ICache, CacheAccess>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}