using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Multimap<TKey, TValue> : IDictionary<TKey, List<TValue>>
    {
        //KeyValuePair<TKey, List<TValue>>[] source;

        //the inner implementation of a multimap is an array of linkedList nodes. Each node contains the key value pairs of the multimap.
        //we get the hash code of the key, and we get an integer which represents the indexof the inner array.
        //

        //private LinkedList<KeyValuePair<TKey,List<TValue>>> []testsource;
        
        private Dictionary<TKey, List<TValue>> source;
        public List<TValue> this[TKey key]
        {
            get
            {
                if (!source.ContainsKey(key))
                {
                    throw new Exception("Key does not exist");
                }
                return source[key];
            }
            set
            {
                if (!source.ContainsKey(key))
                {
                    throw new Exception("Key does not exist");
                }
                source[key] = value;
            }
        }

        public ICollection<TKey> Keys => source.Select(k => k.Key).ToList();

        public ICollection<List<TValue>> Values => source.Select(v => v.Value).ToList();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();


        public Multimap()
        {
            source = new Dictionary<TKey, List<TValue>>();
        }

        public void Add(TKey key, List<TValue> value)
        {
            if (key == null)
            {
                throw new Exception("Key can not be null");
            }
            if (value == null)
            {
                throw new Exception("value can not be null");
            }
            //if the key already exist, add the additional values to the existing values.
            if (source.ContainsKey(key))
            {
                source[key].Concat(value);
            }
            //if the key does not exist, create new key with values.
            source.Add(key, value);
            
        }

        public void Add(KeyValuePair<TKey, List<TValue>> item)
        {
            if (item.Key == null)
            {
                throw new Exception("Key can not be null");
            }
            if (item.Value == null)
            {
                throw new Exception("value can not be null");
            }
            if (source.ContainsKey(item.Key))
            {
                throw new Exception("Key already exists");
            }
            source.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            source.Clear();
        }

        public bool Contains(KeyValuePair<TKey, List<TValue>> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            if (key == null)
            {
                throw new Exception("Key can not be null");
            }
            if (source.ContainsKey(key))
            {
                return false;
            }
            return true;
        }

        public void CopyTo(KeyValuePair<TKey, List<TValue>>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, List<TValue>>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, List<TValue>> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out List<TValue> value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}