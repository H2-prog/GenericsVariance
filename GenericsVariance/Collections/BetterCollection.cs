using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsVariance.Collections
{
    public class BetterCollection<T, R> : IBetterCollection<T, R>
        where T : R
    {
        private List<R> _collection;

        public BetterCollection()
        {
            _collection = new List<R>();
        }

        public int Count
        {
            get { return _collection.Count; }
        }

        public R Get(int index)
        {
            return _collection[index];
        }

        public int Set(T obj)
        {
            _collection.Add(obj);
            return (_collection.Count - 1);
        }
    }
}
