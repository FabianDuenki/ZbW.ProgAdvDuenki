using System;
using System.Collections;

namespace _1._3_ArrayListOperationen {
    // TODO: Delegate "Action"
    // public delegate ...

    // TODO: Delegate "Predicate"
    // public delegate ...

    class Program {
        static void Main() {
            ArrayList list = GetNameList();


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Liste aller Namen:");

            // TODO: list ausgeben (Methode ForAll)
            // ForAll(list, ...);


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Liste aller Namen mit 'S':");

            // TODO: list auf Namen beginnend mit "S" filtern mit anonymer Methode (Methode Find)
            // ArrayList listStartsWithS = ...

            // TODO: listStartsWithS ausgeben (Methode ForAll)
            // ForAll(list, ...);


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Liste aller Namen mit Länge >= 15:");

            // TODO: list auf Namen mit Länge >= 15 filtern mit anonymer Methode (Methode Find)
            // ArrayList listLength15Plus = ...

            // TODO: listLength15Plus ausgeben (Methode ForAll)
            // ForAll(list, ...);


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Konkatenierter String:");

            string concatenated = String.Empty;

            // TODO: list in einen string konkatenieren (Methode ForAll)
            // ForAll(list, ...);

            // TODO: string "concatenated" auf Konsole ausgeben

            Console.ReadKey();
        }

        // TODO: Methode ForAll(...) implementieren
        // private static void ForAll(ArrayList list, Action action)

        // TODO: Methode Find(...) implementieren
        // private static ArrayList Find(ArrayList list, Predicate predicate)

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
