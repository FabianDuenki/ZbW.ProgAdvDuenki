using System;
using _1._2_CounterLib;

namespace _1._2_CounterClient {
    class Program {
        // TODO:
        // Event-Handler Methode "OnCountValueChanged"
        // static void ...
        static void OnCountValueChanged(Counter c, CounterEventArgs arg) {
            Console.WriteLine("Counter changed: Value = {0}", arg.Value);
        }

        [STAThread]
        static void Main(string[] args) {
            // TODO:
            // Counter auf den Initialwert "10" setzen
            Counter myCounter = new Counter(10);

            // TODO:
            // CounterObserver-Instanzen "myObserver1" / "myObserver2" mit den Namen  "obs1" / "obs2"
            CounterObserver myObserver1 = new CounterObserver("obs1");
            CounterObserver myObserver2 = new CounterObserver("obs2");

            // TODO:
            // Registrieren der Event-Handler
            myCounter.CountValueChanged += OnCountValueChanged; // oder ... += new CounterEventHandler(OnCountValueChanged);
            myCounter.CountValueChanged += myObserver1.OnCountValueChanged; // oder ... += new CounterEventHandler(myObserver1.OnCountValueChanged);
            myCounter.CountValueChanged += myObserver2.OnCountValueChanged; // oder ... += new CounterEventHandler(myObserver2.OnCountValueChanged);

            // TODO:
            // Inkrementieren des Counters
            myCounter.Increment();

            // TODO:
            // Deregistrieren des Events von myObserver1
            myCounter.CountValueChanged -= myObserver1.OnCountValueChanged;

            // TODO:
            // Counterwert auf "100" zurücksetzen.
            myCounter.Count = 100;

            Console.ReadKey();
        }

        // TODO:
        // Implementieren Sie die Klasse "CounterObserver"
        // class CounterObserver { ...
        class CounterObserver {
            private string name;

            public CounterObserver(string name) {
                this.name = name;
            }

            public void OnCountValueChanged(Counter c, CounterEventArgs arg) {
                Console.WriteLine("CounterObserver {0}: Counter changed: Value = {1}", name, arg.Value);
            }
        }
    }
}