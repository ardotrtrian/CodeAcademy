using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment8
{
    public class GroupEnumerator<TKey, TElement> : IEnumerator<TElement>
    {
        private readonly TKey Key;

        private readonly Func<TElement, TKey> KeySelector;

        private readonly IEnumerator<TElement> Enumerator;

        private TElement _Current;

        public TElement Current
        {
            get
            {
                return this._Current;
            }
        }
        object IEnumerator.Current
        {
            get
            {
                return this._Current;
            }
        }
        public GroupEnumerator(IEnumerable<TElement> elements, TKey key, Func<TElement, TKey> keySelector)
        {
            this.Key = key;
            this.KeySelector = keySelector;
            this.Enumerator = elements.GetEnumerator();
        }
        public void Dispose()
        {
            if (Enumerator is IDisposable)
            {
                Enumerator.Dispose();
            }
        }
        public bool MoveNext()
        {
            while (this.Enumerator.MoveNext())
            {
                if (this.Key.Equals(KeySelector(this.Enumerator.Current)))
                {
                    this._Current = this.Enumerator.Current;
                    return true;
                }
            }
            return false;
        }
        public void Reset()
        {
            this.Enumerator.Reset();
        }
    }
}