using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace VisitorManagement.Data.Caching
{
    public class CacheAccess : ICache
    {
        private static Cache _cache = null;

        private static Cache cache
        {
            get 
            {
                if (_cache == null)
                    _cache = (HttpContext.Current == null) ? HttpRuntime.Cache : HttpContext.Current.Cache;

                return _cache;
            }
            set 
            {
                _cache = value;
            }
        }

        public object Get(string key)
        {
            return cache.Get(key);
        }

        public void Add(string key, object value)
        {
            if (value == null) return;
            CacheItemPriority priority = CacheItemPriority.NotRemovable;
            var expiration = TimeSpan.FromMinutes(1);
            cache.Insert(key, value, null, DateTime.MaxValue, expiration, priority, null);
        }

        public void Remove(string key = null)
        {
            if (string.IsNullOrEmpty(key))
            {
                IDictionaryEnumerator allCaches = HttpRuntime.Cache.GetEnumerator();

                while (allCaches.MoveNext())
                {
                    cache.Remove(allCaches.Key.ToString());
                }
                return;
            }
            cache.Remove(key);
        }
    }
}