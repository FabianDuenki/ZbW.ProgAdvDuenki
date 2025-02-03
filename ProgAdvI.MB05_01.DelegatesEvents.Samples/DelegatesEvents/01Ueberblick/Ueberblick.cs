using System;
using DelegatesEvents.Beispiele;

namespace DelegatesEvents.Ueberblick.Ueberblick {
    // Deklaration eines Delegate-Typs
    public delegate void Notifier(string sender);

    class Examples {
        public static void Test() {
            // Deklaration Delegate-Variable
            Notifier greetings;

            // Zuweisung einer Methode
            greetings = new Notifier(SayHi);

            // Kurzform
            greetings = SayHi;

            // Aufruf einer Delegate-Variable
            greetings("John");
        }

        private static void SayHi(string sender) {
            Console.WriteLine("Hello {0}", sender);
        }

        private void SayInstance(string sender) {
            Console.WriteLine("Instance {0}", sender);
        }
    }
}
