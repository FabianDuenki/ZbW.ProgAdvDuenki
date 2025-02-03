using System;

namespace _1._2_CounterLib {
    // TODO: Klasse CounterEventArgs implementieren
    public class CounterEventArgs : EventArgs {
        public CounterEventArgs(int value) {
            Value = value;
        }

        public int Value { get; private set; }
    }

    // TODO: Delegate CounterEventHandler
    public delegate void CounterEventHandler(Counter c, CounterEventArgs args);

    // TODO: Klasse Counter implementieren
    public class Counter {
        private int count;

        public event CounterEventHandler CountValueChanged;

        public Counter() : this(0) {
        }

        public Counter(int value) {
            count = value;
        }

        public int Count {
            get { return count; }
            set {
                count = value;
                CountValueChanged?.Invoke(this, new CounterEventArgs(count));
            }
        }

        public int Increment() {
            return ++Count;
        }

        public int Decrement() {
            return --Count;
        }

        public void Reset() {
            Count = 0;
        }

        public void Reset(int value) {
            Count = value;
        }
    }
}