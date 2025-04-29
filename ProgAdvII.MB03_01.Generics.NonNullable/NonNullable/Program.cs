using System;

namespace NonNullable {
    class NullableRefTypes {
        public static void Main() {
            try {
                string Name = null;
                Print("Guten Tag, " + Name);
                Console.WriteLine($"Ihr Name ist {Name.Length} Zeichen lang!");
            } catch (System.Exception ex) {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            Console.WriteLine(nameof(NullableRefTypes) + ": 2. Person");
            try {
                Person p1 = new Person() {ID = 123, Surname = "Schwichtenberg"};
                PrintPerson(p1);
                Person p2 = null;
                PrintPerson(p2);

                p1.Firstname = null;
                string name = p1.Firstname.ToUpper();
                Console.WriteLine(name);
            } catch (System.Exception ex) {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        static void Print(string s) {
            Console.WriteLine(s.Trim());
        }

        static void PrintPerson(Person p) {
            Console.WriteLine($"{p.ID}: {p.ToString()}");
        }

        class Person {
            public int ID { get; set; }
            public string Firstname { get; set; }
            public string Surname { get; set; }

            public Person() {
            }

            public Person(int ID) : this() {
                this.ID = ID;
            }

            public override string ToString() {
                return this.Firstname.ToUpper() + " " + this.Surname.ToUpper();
            }
        }
    }

}