using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enyim.Caching.Memcached;

namespace Demo.MemCached
{
    class Program
    {
        static void Main(string[] args)
        {
            //var client= MemCachedHelper.getInstance();
            //client.Store(StoreMode.Set,"abc", "123");

            //string abc = client.Get<string>("abc");
            //Console.WriteLine(abc);

            MemCachedManage memCachedManage = new MemCachedManage();
            
            memCachedManage.Set("abc", "123");
            string abc = memCachedManage.Get<string>("abc");
            Console.WriteLine(abc);

            //MemCachedManage m2 = new MemCachedManage();

            //m2.Set("xyz", "xyz");
            //string xyz = m2.Get<string>("xyz");
            //Console.WriteLine(xyz);

            memCachedManage.Clear();

            Console.ReadKey();
        }
    }
}
