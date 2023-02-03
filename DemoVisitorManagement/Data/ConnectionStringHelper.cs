using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

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