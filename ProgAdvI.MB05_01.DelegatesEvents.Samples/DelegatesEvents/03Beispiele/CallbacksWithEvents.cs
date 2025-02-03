using System;
using System.Windows.Forms;

namespace DelegatesEvents.Beispiele.WithEvents {
    public delegate void TickEventHandler(int ticks, int interval);

    public class Clock {
        private Timer myTimer = new Timer();
        private int ticks = 0;
        private int interval = 0;
        public event TickEventHandler OnTickEvent;

        public Clock(int interval) {
            this.interval = interval;
            myTimer.Interval = interval;
            myTimer.Tick += Tick;
            myTimer.Start();
        }

        //public void add_OnTickEvent(TickEventHandler h) { OnTickEvent += h; }
        //public void remove_OnTickEvent(TickEventHandler h) { OnTickEvent -= h; }

        private void Tick(object sender, EventArgs e) {
            ticks++;
            OnTickEvent?.Invoke(ticks, interval);
        }
    }

    public class CallbacksWithEventsTest {
        public static void Test() {
            Clock c1 = new Clock(1000);
            Clock c2 = new Clock(2000);

            ClockObserver t1 = new ClockObserver("Observer 1");
            ClockObserver t2 = new ClockObserver("Observer 2");

            // Observers anmelden 
            c1.OnTickEvent += t1.InstanceClockTicked;
            c1.OnTickEvent += ClockObserver.StaticClockTicked;
            c2.OnTickEvent += t2.InstanceClockTicked;
            c2.OnTickEvent += ClockObserver.StaticClockTicked;

            // Achtung: Nicht nachmachen!
            while (true) {
                // Processes all the events in the queue.
                Application.DoEvents();
            }

            // Observers abmelden 
            c1.OnTickEvent -= t1.InstanceClockTicked;
            c2.OnTickEvent -= t2.InstanceClockTicked;
        }
    }
    public class ClockObserver {
        private string name;
        public ClockObserver(string name) { this.name = name; }

        public static void StaticClockTicked(int ticks, int interval) {
            Console.WriteLine("{0}. Tick von Clock mit Interval {1}.", ticks, interval);
        }

        public void InstanceClockTicked(int ticks, int interval) {
            Console.WriteLine("Observer {0} : Clock mit Interval {2} hat zum {1}. Mal getickt.", name, ticks, interval);
        }
    }
}