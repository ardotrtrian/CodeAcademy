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
        private readonly Dictionary<TKey, List<TValue>> source;

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

        public int Count
        {
            get
            {
                return source.Keys.Count;
            }
        }

        public bool IsReadOnly => false;

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
                throw new Exception("Key already exists");
            }
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
            if (source == null)
            {
                throw new Exception("Multimap is empty");
            }
            source.Clear();
        }

        public bool Contains(KeyValuePair<TKey, List<TValue>> item)
        {
            if (item.Key == null || item.Value == null)
            {
                throw new Exception("Key or value can not be null");
            }
            if (source.Contains(item))
            {
                return true;
            }
            return false;
        }


        public bool ContainsKey(TKey key)
        {
            if (key == null)
            {
                throw new Exception("Key can not be null");
            }
            if (source.ContainsKey(key))
            {
                return true;
            }
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, List<TValue>>[] array, int arrayIndex)
        {
            if (arrayIndex < 0)
            {
                throw new Exception("Index is less than zero");
            }
            if (this.source.Count > array.Length - arrayIndex)
            {
                throw new Exception("number of elements in source is greater than available space in array");
            }

            var allKeys = Keys.ToList();

            for (int i = 0; i < source.Count; i++)
            {
                var currentKey = allKeys[i];
                var currentValue = source[allKeys[i]];
                array[i] = new KeyValuePair<TKey, List<TValue>>(currentKey, currentValue);
            }
        }

        public bool Remove(TKey key)
        {
            if (key == null)
            {
                throw new Exception("Key is null");
            }
            if (!source.ContainsKey(key))
            {
                return false;
            }
            source.Remove(key);
            return true;
        }

        public bool Remove(KeyValuePair<TKey, List<TValue>> item)
        {
            bool removedOrNo = Remove(item.Key);
            return removedOrNo;
        }

        public bool TryGetValue(TKey key, out List<TValue> value)
        {
            if (key == null)
            {
                throw new Exception("Key is null");
            }
            if (!source.ContainsKey(key))
            {
                value = null;
                return false;
            }
            value = source[key];
            return true;
        }

        public IEnumerator<KeyValuePair<TKey, List<TValue>>> GetEnumerator()
        {
            return this.source.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}