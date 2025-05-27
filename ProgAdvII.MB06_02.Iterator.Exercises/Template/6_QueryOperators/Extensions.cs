using System;
using System.Collections;
using System.Collections.Generic;

namespace _6_ExtensionMethodsSimple {
    public static class Extensions {
        /****** ZbwMultipleOf ******/

        // TODO: Operator 'ZbwMultipleOf' implementieren / Gibt alle Werte zurück, bei denen "x % factor" == 0 ist
        public static IEnumerable<int> ZbwMultipleOf(this int[] numbers, int factor)
        {
            foreach(int number in numbers){
                if(number % factor == 0) yield return number;
            }
        }
        /****** ZbwWhere ******/

        // TODO: Operator 'ZbwWhere' implementieren / Gibt alle Werte zurück, bei denen ein "Predicate<T>" true liefert
        public static T ZbwWhere<T>(Predicate<T> predicate)
        {
            return default(T);
        }
    }
}