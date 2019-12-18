using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment8
{
    //internal class OrderEnumerable<TSource, TKey> : IOrderedEnumerable<TSource>
    //{
    //    private readonly IEnumerable<TSource> Source;

    //    private readonly Func<TSource, TKey> KeySelector;

    //    private readonly IComparer<TKey> Comparer;

    //    private readonly List<TSource> OrderedList;


    //    public OrderEnumerable(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, bool descending, IComparer<TKey> comparer)
    //    {
    //        this.Source = source;
    //        this.KeySelector = keySelector;
    //        this.Comparer = comparer;
    //        this.OrderedList = new List<TSource>();

    //        if (descending)
    //        {
    //            this.DescendingSort();
    //        }
    //        else
    //        {
    //            this.AscendingSort();
    //        }

    //    }
    //    private void DescendingSort()
    //    {
    //        IEnumerator<TSource> enumerator = this.Source.GetEnumerator();

    //        TSource current;

    //        if (enumerator.MoveNext())
    //        {
    //            this.OrderedList.Add(enumerator.Current);

    //            while (enumerator.MoveNext())
    //            {
    //                current = enumerator.Current;

    //                for (int i = 0; i < this.OrderedList.Count; i++)
    //                {
    //                    if (this.Comparer.Compare(this.KeySelector(current), this.KeySelector(OrderedList[i])) > 0)
    //                    {
    //                        this.OrderedList.Insert(i, current);
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    private void AscendingSort()
    //    {
    //        IEnumerator<TSource> enumerator = this.Source.GetEnumerator();

    //        TSource current;

    //        if (enumerator.MoveNext())
    //        {
    //            this.OrderedList.Add(enumerator.Current);

    //            while (enumerator.MoveNext())
    //            {
    //                current = enumerator.Current;

    //                for (int i = 0; i < OrderedList.Count; i++)
    //                {
    //                    if (this.Comparer.Compare(this.KeySelector(current), this.KeySelector(this.OrderedList[i])) < 0)
    //                    {
    //                        this.OrderedList.Insert(i, current);
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    public IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey1>(Func<TSource, TKey1> keySelector, IComparer<TKey1> comparer, bool descending)
    //    {
    //        return new OrderEnumerable<TSource, TKey1>(this.Source, keySelector, descending, comparer);
    //    }

    //    public IEnumerator<TSource> GetEnumerator()
    //    {
    //        return OrderedList.GetEnumerator();
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return OrderedList.GetEnumerator();
    //    }
    //}
}