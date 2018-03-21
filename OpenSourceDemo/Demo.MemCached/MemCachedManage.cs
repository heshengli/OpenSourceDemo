using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enyim.Caching;

namespace Demo.MemCached
{
    public sealed class MemCachedManage : ICache
    {
        private static MemcachedClient MemClient;

        public MemCachedManage()
        {
            MemClient = MemCachedHelper.getInstance();
        }
        public void Clear()
        {
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public bool IsSet(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void RemoveByPattern(string pattern)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, object data, int cacheTime)
        {
            throw new NotImplementedException();
        }
    }
}
