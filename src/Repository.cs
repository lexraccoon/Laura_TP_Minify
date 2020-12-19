using System.Collections.Generic;
using System.Linq;
using Minify.Interfaces;
using Minify.Model;

namespace Minify
{
    public class Repository: IRepository
    {
        public static List<MinifyData> collection = new List<MinifyData>();

        public void Add(MinifyData minifyData)
        {
            collection.Add(minifyData);
        }

        public IEnumerable<MinifyData> Get()
        {
            return collection;
        }

        public MinifyData Get(string token)
        {
            return collection.FirstOrDefault(data => data.Key == token);
        }

        public void Delete(string key)
        {
            collection.Remove(this.Get(key));
        }
    }
}