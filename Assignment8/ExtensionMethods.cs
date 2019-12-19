using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8
{
    static class ExtensionMethods
    {
        public static IEnumerable<TSource> MyWhere<TSource>
            (this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source != null)
            {
                if (predicate != null)
                {
                    return new WhereEnumerable<TSource>(source, predicate);
                }
                throw new ArgumentNullException("Predicate is null!");
            }
            throw new ArgumentNullException("Source is null!");
        }

        public static IEnumerable<TResult> MySelect<TSource, TResult>
            (this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source != null)
            {
                if (selector != null)
                {
                    return new SelectEnumerable<TSource, TResult>(source, selector);
                }
                throw new ArgumentNullException("selector is null!");
            }
            throw new ArgumentNullException("source is null!");
        }

        public static List<TSource> MyToList<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source is null!");
            }
            return new List<TSource>(source);
        }

        public static Dictionary<TKey, TSource> MyToDictionary<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source != null)
            {
                if (keySelector != null)
                {
                    Dictionary<TKey, TSource> dic = new Dictionary<TKey, TSource>();

                    foreach (var element in source)
                    {
                        if (dic.ContainsKey(keySelector(element)))
                        {
                            throw new Exception("Key Selector must be unique for each element!");
                        }
                        dic.Add(keySelector(element), element);
                    }
                    return dic;
                }
                throw new ArgumentNullException("Key Selector is null!");
            }
            throw new ArgumentNullException("Source is null!");
        }
       
        public static IEnumerable<IGrouping<TKey, TSource>> MyGroupBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source != null)
            {
                if (keySelector != null)
                {
                    return new GroupingEnumerable<TSource,TKey>(source, keySelector);
                }
                throw new ArgumentNullException("Key Selector is null!");
            }
            throw new ArgumentNullException("Source is null!");
        }

        public static IOrderedEnumerable<TSource> MyOrderBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, bool descending=false)
        {
            if (source != null)
            {
                if (keySelector != null)
                {
                    return new OrderEnumerable<TSource, TKey>(source, keySelector, descending, Comparer<TKey>.Default);
                }
                throw new ArgumentNullException("Key Selector is null!");
            }
            throw new ArgumentNullException("Source is null!");
        }
    }
}
