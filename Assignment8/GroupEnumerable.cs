using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment8
{
    //internal class GroupEnumerable<TSource, TKey> : IEnumerable<IGrouping<TSource, TKey>>
    //{
    //    private readonly IEnumerable<TSource> Source;
    //    private readonly Func<TSource, TKey> KeySelector;

    //    public GroupEnumerable(IEnumerable<TSource> source, Func<TSource,TKey> keySelector)
    //    {
    //        this.Source = source;
    //        this.KeySelector = keySelector;
    //    }

    //    public IEnumerator<IGrouping<TSource, TKey>> GetEnumerator()
    //    {
    //        return new GroupEnumerator<TSource, TKey>(this.Source, this.KeySelector);
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return new GroupEnumerator<TSource, TKey>(this.Source, this.KeySelector);
    //    }
    //}
}