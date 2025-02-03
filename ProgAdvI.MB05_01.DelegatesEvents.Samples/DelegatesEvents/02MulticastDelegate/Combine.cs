using System;

namespace DelegatesEvents.MulticastDelegate.Combine {
    public delegate void Notifier(string sender);

    class Examples {
        public void Test() {
            Notifier a = SayHi;
            Notifier b = SayCiao;
            Notifier c = a + b;
            c = a - b;
            Notifier d = (Notifier) Delegate.Combine(a, b);
            c("John");
            d("John");
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
