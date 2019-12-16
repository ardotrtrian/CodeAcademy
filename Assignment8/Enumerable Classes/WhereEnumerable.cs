using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment8
{
    internal class WhereEnumerable<TSource> : IEnumerable<TSource>
    {
        private readonly IEnumerable<TSource> Source;
        private readonly Func<TSource, bool> Predicate;

        public WhereEnumerable(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            this.Source = source;
            this.Predicate = predicate;
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            return new WhereEnumerator<TSource>(this.Source, this.Predicate);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new WhereEnumerator<TSource>(this.Source, this.Predicate);
        }
    }
}