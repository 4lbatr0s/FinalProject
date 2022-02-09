using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcern.Caching
{
    interface ICacheManager
    {
        //
        //object value: value that we put into Cache
        //duration: cache duration
        void Add(string key, object value, int duration);

        T Get<T>(string key); //explanation: I'll send you a key value, depending on that, send me the value from the cache
        bool IsAdd(string key); //check whether it's in cache or not.
        void Remove(string key); //remove the value from the cache.
        void RemoveByPattern(string pattern); //for instance: remove values that contains "Get" word.
    }
}
