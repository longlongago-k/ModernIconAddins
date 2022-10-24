using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernIconLib.Extension
{
    public static  class Extensions
    {
        public static bool Contains(this string src, string text, StringComparison stringComparison)
        {
            return (src.IndexOf(text, 0, stringComparison) != -1);
        }

        //IEnumerableの拡張メソッド、指定された個数で要素をまとめて返す
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunksize)
        {
            if (chunksize <= 0) throw new ArgumentException();
            var loopCount = source.Count() / chunksize + (source.Count() % chunksize > 0 ? 1 : 0);
            foreach (var i in Enumerable.Range(0, loopCount))
            {
                yield return source.Skip(chunksize * i).Take(chunksize);
            }
        }
    }
}
