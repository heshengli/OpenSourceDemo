using System;
using System.Net;
using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;

namespace Demo.MemCached
{
    public class MemCachedHelper
    {
        private static MemcachedClient MemClient;
        static readonly object padlock = new object();
        //线程安全的单例模式
        public static MemcachedClient getInstance()
        {
            if (MemClient == null)
            {
                lock (padlock)
                {
                    if (MemClient == null)
                    {
                        //MemClientInit();
                        MemClient = new MemcachedClient();
                    }
                }
            }
            return MemClient;
        }
        static void MemClientInit()
        {
            //初始化缓存
            MemcachedClientConfiguration memConfig = new MemcachedClientConfiguration();
            IPAddress newaddress =
                IPAddress.Parse(Dns.GetHostEntry
                    ("your_ocs_host").AddressList[0].ToString());//your_ocs_host替换为OCS内网地址
            IPEndPoint ipEndPoint = new IPEndPoint(newaddress, 11211);
            // 配置文件 - ip
            memConfig.Servers.Add(ipEndPoint);
            // 配置文件 - 协议
            memConfig.Protocol = MemcachedProtocol.Binary;
            // 配置文件-权限
            memConfig.Authentication.Type = typeof(PlainTextAuthenticator);
            memConfig.Authentication.Parameters["zone"] = "";
            memConfig.Authentication.Parameters["userName"] = "username";
            memConfig.Authentication.Parameters["password"] = "password";
            //下面请根据实例的最大连接数进行设置
            memConfig.SocketPool.MinPoolSize = 5;
            memConfig.SocketPool.MaxPoolSize = 200;
            MemClient = new MemcachedClient(memConfig);
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
    }
}