using System;

namespace DelegatesEvents.Ueberblick.VergleichInterface {
    public interface INotifier {
        void Notify(string sender);
    }

    class Examples {
        public void Test() {
            // Deklaration Delegate-Variable
            INotifier greetings;

            // Zuweisung einer Methode
            greetings = new NotifierImpl();

            // Aufruf einer Delegate-Variable
            greetings.Notify("John");
        }
    }

    public class NotifierImpl : INotifier {
        public void Notify(string sender) {
            Console.WriteLine("Hello {0}", sender);
        }
    }
}