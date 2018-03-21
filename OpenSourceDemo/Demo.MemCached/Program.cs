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
            var client= MemCachedHelper.getInstance();
            client.Store(StoreMode.Set,"abc", "123");

            string abc = client.Get<string>("abc");
            Console.WriteLine(abc);
            Console.ReadKey();
        }
    }
}
