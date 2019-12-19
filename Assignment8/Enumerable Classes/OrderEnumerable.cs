using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment8
{
    internal class OrderEnumerable<TSource, TKey> : IOrderedEnumerable<TSource>
    {
        private readonly IEnumerable<TSource> Source;
        private readonly Func<TSource, TKey> KeySelector;
        private readonly bool Descending;
        private readonly Comparer<TKey> Comparer;
        private readonly List<TSource> OrderedList;

        public OrderEnumerable(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, bool descending, Comparer<TKey> comparer)
        {
            this.Source = source;
            this.KeySelector = keySelector;
            this.Comparer = comparer;
            this.OrderedList = new List<TSource>();
            this.Descending = descending;

            if (this.Descending)
            {
                DescendingSort();
            }
            else
            {
                AscendingSort();
            }
            //Sort();
        }

        private void AscendingSort()
        {
            IEnumerator<TSource> enumerator = this.Source.GetEnumerator();

            TSource current;

            if (enumerator.MoveNext())
            {
                this.OrderedList.Add(enumerator.Current);

                while (enumerator.MoveNext())
                {
                    current = enumerator.Current;

                    int size = OrderedList.Count;

                    for (int i = 0; i < size; i++)
                    {
                        if (this.Comparer.Compare(this.KeySelector(current), this.KeySelector(this.OrderedList[i])) < 0 )
                        {
                            this.OrderedList.Insert(i, current);
                            break;
                        }
                        if (i == size - 1)
                        {
                            this.OrderedList.Add(current);
                        }
                    }
                }
            }
        }

        private void DescendingSort()
        {
            IEnumerator<TSource> enumerator = this.Source.GetEnumerator();
            TSource current;

            if (enumerator.MoveNext())
            {
                this.OrderedList.Add(enumerator.Current);

                while (enumerator.MoveNext())
                {
                    current = enumerator.Current;

                    int size = OrderedList.Count;

                    for (int index = 0; index < size; index++)
                    {
                        if (this.Comparer.Compare(this.KeySelector(current), this.KeySelector(this.OrderedList[index])) > 0)
                        {
                            this.OrderedList.Insert(index, current);
                            break;
                        }
                        if (index == size - 1)
                        {
                            this.OrderedList.Add(current);
                        }
                    }
                }
            }
        }

        public IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey1>(Func<TSource, TKey1> keySelector, IComparer<TKey1> comparer, bool descending)
        {
            return new OrderEnumerable<TSource, TKey>(this.Source, this.KeySelector, this.Descending, this.Comparer);
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            return this.OrderedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.OrderedList.GetEnumerator();
        }
    }
}