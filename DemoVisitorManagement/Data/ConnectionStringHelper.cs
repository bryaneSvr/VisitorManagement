using System.Configuration;

namespace VisitorManagement.Data
{
    public static class ConnectionStringHelper
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["VisitorRepository"].ConnectionString;
        }
    }
}