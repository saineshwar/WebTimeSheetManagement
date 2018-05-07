using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
namespace WebTimeSheetManagement.Helpers
{
    public class CacheManager : ICacheManager
    {
        /// <summary>
        /// <see cref="ICacheManager.Add(string, object)"/> 
        /// </summary>
        /// <param name="key"><see cref="ICacheManager.Add(string, object)"/></param>
        /// <param name="value"><see cref="ICacheManager.Add(string, object)"/></param>
        void ICacheManager.Add(string key, object value)
        {
            ObjectCache cacheInstance = MemoryCache.Default;

            if (cacheInstance.Contains(key))
            {
                cacheInstance.Remove(key);
            }

            cacheInstance.Add(key, value, ObjectCache.InfiniteAbsoluteExpiration);
        }

        /// <summary>
        /// <see cref="ICacheManager.Get(string)"/> 
        /// </summary>
        /// <typeparam name="T"><see cref="ICacheManager.Get(string)"/></typeparam>
        /// <param name="key"><see cref="ICacheManager.Get(string)"/></param>
        T ICacheManager.Get<T>(string key)
        {
            ObjectCache cacheInstance = MemoryCache.Default;

            if (cacheInstance.Contains(key))
            {
                return (T)cacheInstance[key];
            }

            return null;
        }

        /// <summary>
        /// <see cref="ICacheManager.Clear(string)"/> 
        /// </summary>
        /// <param name="key"><see cref="ICacheManager.Clear(string)"/></param>
        void ICacheManager.Clear(string key)
        {
            ObjectCache cacheInstance = MemoryCache.Default;

            if (cacheInstance.Contains(key))
            {
                cacheInstance.Remove(key);
            }
        }
    }
}