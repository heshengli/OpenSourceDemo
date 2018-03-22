using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enyim.Caching;
using Enyim.Caching.Memcached;

namespace Demo.MemCached
{
    public sealed class MemCachedManage : ICache
    {
        private static MemcachedClient MemClient;

        private static MemCachedManage instance;

        public MemCachedManage()
        {
        }

        static MemCachedManage()
        {
            MemClient = MemcachedClientFactory.GetInstance();
            instance = new MemCachedManage();
        }

        public static ICache Instance
        {
            get { return instance; }
        }


        public void Clear()
        {
            MemClient.FlushAll();
        }

        public void Dispose()
        {
            MemClient = null;
        }

        public T Get<T>(string key)
        {
            try
            {
                return MemClient.Get<T>(key);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public bool IsSet(string key)
        {
            try
            {
                return MemClient.Get(key) != null;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public void Remove(string key)
        {
            try
            {
                MemClient.Remove(key);
            }
            catch (Exception)
            {
                //igore
            }
        }

        public void RemoveByPattern(string pattern)
        {
            //
        }

        public void Set(string key, object data, int cacheTime)
        {
            try
            {
                MemClient.Store(StoreMode.Set, key, data, DateTime.Now.AddSeconds(cacheTime));
            }
            catch (Exception)
            {
                //igore
            }
        }

        public void Set(string key, object data)
        {
            try
            {
                MemClient.Store(StoreMode.Set, key, data);
            }
            catch (Exception)
            {
                //igore
            }
        }
    }
}
