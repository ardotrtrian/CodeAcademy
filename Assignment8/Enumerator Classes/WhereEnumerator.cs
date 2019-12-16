using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8
{
    public class WhereEnumerator<TSource> : IEnumerator<TSource>
    {
        private readonly IEnumerator<TSource> Source;
        private readonly Func<TSource, bool> Predicate;

        public WhereEnumerator(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            this.Source = source.GetEnumerator();
            this.Predicate = predicate;
        }

        public TSource Current { get; set; }

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
            while(this.Source.MoveNext())
            {
                Current = Source.Current;

                if (this.Predicate(Current))
                {
                    return true;
                }
            }
            return false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
