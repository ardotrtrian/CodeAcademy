using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment8
{
    internal class SelectEnumerable<TSource, TResult> : IEnumerable<TResult>
    {
        private readonly IEnumerable<TSource> Source;
        private readonly Func<TSource, TResult> Selector;

        public SelectEnumerable(IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            this.Source = source;
            this.Selector = selector;
        }

        public IEnumerator<TResult> GetEnumerator()
        {
            return new SelectEnumerator<TSource,TResult>(Source, Selector);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new SelectEnumerator<TSource,TResult>(Source, Selector);
        }
    }
}