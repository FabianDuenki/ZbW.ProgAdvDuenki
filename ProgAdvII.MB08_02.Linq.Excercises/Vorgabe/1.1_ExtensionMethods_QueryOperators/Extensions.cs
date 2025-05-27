using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;

namespace _1._1_ExtensionMethods_QueryOperators {
    /// <summary>
    /// Dokumentation der offiziellen LINQ Extension Methods:
    /// http://msdn.microsoft.com/en-us/library/system.linq.enumerable_methods.aspx
    /// 
    /// Nutzen Sie diese Dokumentation um Ihre Extension Methods zu implementieren.
    /// Sie finden dort auch die Beschreibung, was die Methode effektiv für einen Effekt hat.
    /// </summary>
    public static class Extensions {
        public static void ZbwForEach<T>(this IEnumerable<T> values, Action<T> action)
        {
            foreach (var item in values)
            {
                action(item);
            }
        }
        public static IEnumerable<T> ZbwWhere<T>(this IEnumerable<T> values, Predicate<T> predicate)
        {
            foreach (var item in values)
            {
                if (predicate(item)) yield return item;
            }
        }
        public static IEnumerable<T> ZbwOfType<T>(this IEnumerable values)
        {
            foreach(var item in values)
            {
                if (item is T itemT) yield return itemT;
            }
        }
        public static List<T> ZbwToList<T>(this IEnumerable<T> values)
        {
            return values.ToList();
        }
        public static int ZbwSum<T>(this IEnumerable<T> values, Func<T, int> selector)
        {
            int sum = 0;
            foreach (var item in values)
            {
                sum += selector(item);
            }
            return sum;
        }
    }
}