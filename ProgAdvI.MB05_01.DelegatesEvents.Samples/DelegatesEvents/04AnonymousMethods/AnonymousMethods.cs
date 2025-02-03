using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents.Summary {
    class AnonymousMethods {
        int sum = 0;

        void SumUp(int i) {
            sum += i;
        }

        //void Print(int i) {
        //    Console.WriteLine(i);
        //}

        public void Foo() {
            List<int> list = new List<int> {3, 6, 8, 10};
            list.ForEach(SumUp);
            //list.ForEach(Print);
            list.ForEach(delegate (int i) {
                Console.WriteLine(i);
            });














            int sum = 0;

            list.ForEach(delegate(int i) { Console.WriteLine(i); });
            list.ForEach(delegate(int i) {
                sum += i;
            });

            list.ForEach(delegate { Console.WriteLine("Hello"); });
            list.ForEach(delegate { sum += 1; });

            int a = 1;
            int b;
            Test(a, out b);
            Console.WriteLine(b);
        }

        public void Test(int a, out int b) {
            b = 5;
        }
    }
}