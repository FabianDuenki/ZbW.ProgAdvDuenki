using System;
using System.Collections;

namespace _1._3_ArrayListOperationen {
    // TODO: Delegate "Action"
    // public delegate ...
    public delegate void Action(string i);

    // TODO: Delegate "Predicate"
    // public delegate ...
    public delegate bool Predicate(string s);

    class Program {
        static void Main() {
            ArrayList list = GetNameList();


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Liste aller Namen:");

            // TODO: list ausgeben (Methode ForAll)
            // ForAll(list, ...);
            ForAll(list, Console.WriteLine);


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Liste aller Namen mit 'S':");

            // TODO: list auf Namen beginnend mit "S" filtern mit anonymer Methode (Methode Find)
            // ArrayList listStartsWithS = ...
            ArrayList listStartsWithS = Find(list, delegate(string s) { return s.StartsWith("S"); });

            // TODO: listStartsWithS ausgeben (Methode ForAll)
            // ForAll(list, ...);
            ForAll(listStartsWithS, Console.WriteLine);


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Liste aller Namen mit Länge >= 15:");

            // TODO: list auf Namen mit Länge >= 15 filtern mit anonymer Methode (Methode Find)
            // ArrayList listLength15Plus = ...
            ArrayList listLength15Plus = Find(list, delegate(string s) { return s.Length >= 15; });

            // TODO: listLength15Plus ausgeben (Methode ForAll)
            // ForAll(list, ...);
            ForAll(listLength15Plus, Console.WriteLine);


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Konkatenierter String:");

            string concatenated = String.Empty;

            // TODO: list in einen string konkatenieren (Methode ForAll)
            // ForAll(list, ...);
            ForAll(list, delegate(string s) { concatenated += s + " / "; });

            // TODO: string "concatenated" auf Konsole ausgeben
            Console.WriteLine(concatenated);

            Console.ReadKey();
        }

        // TODO: Methode ForAll(...) implementieren
        // private static void ForAll(ArrayList list, Action action)
        private static void ForAll(ArrayList list, Action action) {
            if (action == null) {
                return;
            }

            // TODO: Ausführung von action implementieren
            foreach (string s in list) {
                action(s);
            }
        }

        // TODO: Methode Find(...) implementieren
        // private static ArrayList Find(ArrayList list, Predicate predicate)
        private static ArrayList Find(ArrayList list, Predicate predicate) {
            ArrayList filtered = new ArrayList();
            if (predicate == null) {
                return filtered;
            }

            // TODO: Suche implementieren
            foreach (string s in list) {
                if (predicate(s)) {
                    filtered.Add(s);
                }
            }

            return filtered;
        }

        private static ArrayList GetNameList() {
            return new ArrayList {
                "Shaun Byler",
                "Regenia Politte",
                "Earleen Huard",
                "Evelin Svoboda",
                "Phuong Briese",
                "Shea Sailor",
                "Kerri Seese",
                "Dulce Spalla",
                "Cedrick Bohr",
                "Pearline Abele",
                "Chas Grossi",
                "Teresa Winkelman",
                "Marilee Keaton",
                "Karisa Millender",
                "Nickie Borders",
                "Hoyt Eicher",
                "Ula Harjo",
                "Willodean Byerly",
                "Sirena Vives",
                "Johnnie Folkers"
            };
        }
    }
}