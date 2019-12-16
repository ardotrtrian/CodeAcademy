using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8
{
    static class ExtensionMethods
    {
        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source !=null)
            {
                if (predicate != null)
                {
                    return new WhereEnumerable<TSource>(source, predicate);
                }
                throw new ArgumentNullException("Predicate is null!");
            }
            throw new ArgumentNullException("Source is null!");
        }

    }
}
