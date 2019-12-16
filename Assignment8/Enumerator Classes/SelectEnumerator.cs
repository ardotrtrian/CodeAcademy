using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment8
{
    internal class SelectEnumerator<TSource, TResult> : IEnumerator<TResult>
    {
        private readonly IEnumerator<TSource> Source;
        private readonly Func<TSource, TResult> Selector;

        public SelectEnumerator(IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            this.Source = source.GetEnumerator();
            this.Selector = selector;
        }

        public TResult Current { get; set; }

        object IEnumerator.Current { get; }

        public void Dispose()
        {
            if (Source is IDisposable)
            {
                Source.Dispose();
            }
        }

        public bool MoveNext()
        {
            while (Source.MoveNext())
            {
                Current = Selector(Source.Current);
                return true;
            }
            return false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}