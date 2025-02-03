using System;

namespace DelegatesEvents.MulticastDelegate {
    public delegate void Notifier(string sender);

    public delegate int GetIntDelegate();

    class Examples {
        public void Test() {
            Notifier greetings = SayHi;

            // Compiler-Output
            greetings += SayHi;
            // nachfolgendes entspricht
            // greetings("John");
            foreach (Delegate del in greetings.GetInvocationList()) {
                ((Notifier) del)("John");
            }

            // Beispiel +=
            greetings += SayHi;
            greetings += SayCiao;
            greetings += SayHi;

            greetings("John");

            // Beispiel -=
            Console.WriteLine("---------");
            greetings -= SayHi;
            greetings("John");

            // Beispiel Rückgabewert
            Console.WriteLine("---------");
            GetIntDelegate intDelegate = Get1;
            intDelegate += Get2;
            intDelegate += Get3;
            int i = intDelegate();

            // Beispiel + / Combine
            Notifier n1 = SayHi;
            Notifier n2 = SayCiao;

            Notifier c1 = n1 + n2;
            c1("John");
            Notifier c2 = (Notifier) Delegate.Combine(n1, n2);
            c2("John");
        }

        private void SayHi(string sender) {
            Console.WriteLine("Hello {0}", sender);
        }

        private void SayCiao(string sender) {
            Console.WriteLine("Good bye {0}", sender);
        }

        private int Get1() {
            return 1;
        }

        private int Get2() {
            return 2;
        }

        private int Get3() {
            return 3;
        }
    }
}
