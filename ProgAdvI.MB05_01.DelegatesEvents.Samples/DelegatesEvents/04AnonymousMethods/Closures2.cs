using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents._04AnonymousMethods {
    public static class Closures2 {
        public static void Run() {
            var actions = new List<Action>();
            for (int i = 0; i < 3; i++)
                actions.Add(() => Console.WriteLine(i));
            foreach (var action in actions)
                action();
        }


        //public static void Run2() {
        //    var actions = new List<Action>();
        //    DisplayClass c = new DisplayClass();
        //    for (c.i = 0; c.i < 3; c.i++)
        //        actions.Add(c.Action);
        //    foreach (Action action in actions)
        //        action();
        //}

        //private sealed class DisplayClass {
        //    public int i;

        //    public void Action() {
        //        Console.WriteLine(i);
        //    }
        //}
    }
}
