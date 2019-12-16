using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment8
{
    internal class SelectEnumerable<TSource, TResult> : IEnumerable<TResult>
    {
        private IEnumerable<TSource> source;
        private Func<TSource, TResult> selector;

        public SelectEnumerable(IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            this.source = source;
            this.selector = selector;
        }

        public IEnumerator<TResult> GetEnumerator()
        {
            return new SelectEnumerator<TSource,TResult>(source, selector);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new SelectEnumerator<TSource,TResult>(source, selector);
        }
    }
}