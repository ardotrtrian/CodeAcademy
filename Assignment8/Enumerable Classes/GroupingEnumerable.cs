using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment8
{
    internal class GroupingEnumerable<TSource, TKey> : IEnumerable<IGrouping<TKey, TSource>>
    {
        private readonly IEnumerable<TSource> Source;
        private readonly Func<TSource, TKey> KeySelector;

        public GroupingEnumerable(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            this.Source = source;
            this.KeySelector = keySelector;
        }

        public IEnumerator<IGrouping<TKey, TSource>> GetEnumerator()
        {
            return new GroupingEnumerator<TKey, TSource>(this.Source, this.KeySelector);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new GroupingEnumerator<TKey, TSource>(this.Source, this.KeySelector);
        }
    }
}