using System;
using System.Collections.Generic;

namespace DelegatesEvents.AnonymousMethods.Closure1 {

    //[CompilerGenerated]
    //private sealed class <>c__DisplayClass2
    //{
    //    public <>c__DisplayClass2();
    //    public int <CreateAdder>b__0()
    //    {
    //        x++; return x;
    //    }
    //    public int x;
    //}


    public delegate int Adder();

    class Example {
        static Adder CreateAdder() {
            int x = 0;
            return delegate {
                x++;
                return x;
            };
        }

        public static void Test() {
            Adder add = CreateAdder();
            Console.WriteLine(add());
            Console.WriteLine(add());
            Console.WriteLine(add());
        }
    }
}

