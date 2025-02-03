using System;

namespace DelegatesEvents.Beispiele {
    public delegate void Action(int i);

    public class MyClass {
        public static void PrintValues(int i) {
            Console.WriteLine("Value {0}", i);
        }

        public void SumValues(int i) {
            Sum += i;
        }

        public int Sum { get; private set; }
    }

    public class FunctionParameterTest {
        private static void ForAll(int[] array, Action action) {
            Console.WriteLine("ForAll called...");
            if (action == null) {
                return;
            }

            foreach (int t in array) {
                action(t);
            }
        }

        public static void TestSum() {
            MyClass c = new MyClass();
            int[] array = {1, 5, 8, 14, 22};

            // Delegate Variables
            Action v1 = MyClass.PrintValues; // Static
            Action v2 = c.SumValues; // Non-Static

            // Execution
            ForAll(array, v1);
            ForAll(array, null);
            ForAll(array, v2);
            Console.WriteLine("--- Sum {0}", c.Sum);
            ForAll(array, v2);
            Console.WriteLine("--- Sum {0}", c.Sum);
        }
    }
}