using System.Reflection;
using System.Resources;

namespace VisitorManagement.Data
{
    public static class GetMessage
    {
        internal static ResourceManager resourceManager
            = new ResourceManager("VisitorManagement.Messages", Assembly.GetExecutingAssembly());

        public static string DefaultGetKey()
        {
            return resourceManager.GetString("DefaultGetKey");
        }

        public static string Inserted(string records)
        {
            return string.Format(resourceManager.GetString("Inserted"), records);
        }

        public static string Updated(string records)
        {
            return string.Format(resourceManager.GetString("Updated"), records);
        }

        public static string Deleted(string records)
        {
            return string.Format(resourceManager.GetString("Deleted"), records);
        }
    }
}