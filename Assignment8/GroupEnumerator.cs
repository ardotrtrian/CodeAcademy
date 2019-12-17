using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment8
{
    //internal class GroupEnumerator<TSource, TKey> : IEnumerator<IGrouping<TSource, TKey>>
    //{
    //    private readonly IEnumerator<TSource> Source;
    //    private readonly Func<TSource, TKey> KeySelector;

    //    public GroupEnumerator(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    //    {
    //        this.Source = source.GetEnumerator();
    //        this.KeySelector = keySelector;
    //    }

    //    public IGrouping<TSource, TKey> Current { get; set; }

    //    object IEnumerator.Current { get; }

    //    public void Dispose()
    //    {
    //        if (this.Source is IDisposable)
    //        {
    //            Source.Dispose();
    //        }
    //    }

    //    public bool MoveNext()
    //    {
    //        while (Source.MoveNext())
    //        {
    //            if (KeySelector.Equals(Source.Current))
    //            {
    //                Current = Source.Current;
    //                return true;
    //            }
    //        }
    //        return false;
    //    }

    //    public void Reset()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}