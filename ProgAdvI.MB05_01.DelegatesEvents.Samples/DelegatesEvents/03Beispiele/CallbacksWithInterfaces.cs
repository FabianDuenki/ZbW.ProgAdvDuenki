using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DelegatesEvents.Beispiele.WithInterfaces {
    public interface ITickCallback { void OnTickEvent(int ticks, int interval); }

    public class Clock {
        private Timer myTimer = new Timer();
        private int ticks = 0;
        private int interval = 0;
        private List<ITickCallback> tickCallbacks = new List<ITickCallback>();
        private int p;

        public Clock(int interval) {
            this.interval = interval;
            myTimer.Interval = interval;
            myTimer.Tick += Tick;
            myTimer.Start();
        }

        public void add_OnTickEvent(ITickCallback h) { tickCallbacks.Add(h); }
        public void remove_OnTickEvent(ITickCallback h) { tickCallbacks.Remove(h); }

        private void Tick(object sender, EventArgs e) {
            ticks++;
            if (tickCallbacks != null) {
                foreach (ITickCallback tickCallback in tickCallbacks) {
                    tickCallback.OnTickEvent(ticks, interval);
                }
            }
        }
    }

    public class CallbacksWithInterfaceTest {
        public static void Test() {
            Clock c1 = new Clock(1000);
            Clock c2 = new Clock(2000);

            ClockObserver t1 = new ClockObserver("Observer 1");
            ClockObserver t2 = new ClockObserver("Observer 2");

            // Observers anmelden
            c1.add_OnTickEvent(t1);
            c2.add_OnTickEvent(t2);

            // Achtung: Nicht nachmachen!
            while (true) {
                // Processes all the events in the queue.
                Application.DoEvents();
            }

            // Observers abmelden 
            c1.remove_OnTickEvent(t1);
            c2.remove_OnTickEvent(t2);
        }
    }
    public class ClockObserver : ITickCallback {
        private string name;
        public ClockObserver(string name) { this.name = name; }

        public static void StaticClockTicked(int ticks, int interval) {
            Console.WriteLine("{0}. Tick von Clock mit Interval {1}.", ticks, interval);
        }

        public void InstanceClockTicked(int ticks, int interval) {
            Console.WriteLine("Observer {0} : Clock mit Interval {2} hat zum {1}. Mal getickt.", name, ticks, interval);
        }

        public void OnTickEvent(int ticks, int interval) {
            InstanceClockTicked(ticks, interval);
        }
    }
}