using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment8
{
    internal class GroupingEnumerator<TKey, TSource> : IEnumerator<IGrouping<TKey, TSource>>
    {
        private readonly IEnumerable<TSource> Source;

        private readonly Func<TSource, TKey> KeySelector;

        private readonly List<TKey> KeyList;

        private readonly IEnumerator<TSource> Enumerator;

        private IGrouping<TKey, TSource> _Current;

        public IGrouping<TKey, TSource> Current
        {
            get
            {
                return this._Current;
            }
            set
            {
                _Current = value;
            }
        }

        object IEnumerator.Current { get { return this._Current; } }

        public GroupingEnumerator(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            this.Source = source;
            this.KeySelector = keySelector;
            this.KeyList = new List<TKey>();
            this.Enumerator = this.Source.GetEnumerator();
        }

        public void Dispose()
        {
            if (this.Enumerator is IDisposable)
            {
                Enumerator.Dispose();
            }
        }

        public bool MoveNext()
        {
            TKey key;

            while (this.Enumerator.MoveNext())
            {
                key = this.KeySelector(this.Enumerator.Current);

                if (!this.KeyList.Contains(key))
                {
                    this.Current = new Group<TKey, TSource>(key, this.Source, this.KeySelector);
                    this.KeyList.Add(key);
                    return true;
                }
            }
            return false;
        }

        public void Reset()
        {
            this.Enumerator.Reset();
            this.KeyList.Clear();
        }
    }
}