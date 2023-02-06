﻿namespace VisitorManagement.Data.Caching
{
    public interface ICache
    {
        object Get(string key);

        void Add(string key, object value);

        void Remove(string key = null);

    }
}
