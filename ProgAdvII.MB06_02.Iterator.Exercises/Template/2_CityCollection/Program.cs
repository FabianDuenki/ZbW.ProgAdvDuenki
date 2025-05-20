using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _2_CityCollection {
    public class CityCollection : IEnumerable {
        private string[] cities = {"Bern", "Basel", "Zürich", "Rapperswil", "Genf"};

        public IEnumerator GetEnumerator()
        {
            return new CitiesEnumerator(cities);
        }

        public IEnumerable Reverse
        {
            get { return this.cities.Reverse(); }
        }

        class CitiesEnumerator : IEnumerator
        {
            private string[] _cities;
            private int _index = -1;
            public CitiesEnumerator(string[] cities)
            {
                this._cities = cities;
            }
            public object Current
            {
                get
                {
                    return this._cities[_index];
                }
            }
            public bool MoveNext()
            {
                this._index++;
                return this._cities.Length >= (this._index + 1);
            }
            public void Reset()
            {
                this._index = -1;
            }

        }
    }

    class Program {
        static void Main(string[] args) {
            CityCollection myColl = new CityCollection();

            // Ausgabe
            foreach (string s in myColl)
            {
                Console.WriteLine(s);
            }

            // Ausgabe in umgekehrter Reihenfolge 
            foreach (string s in myColl.Reverse)
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();
        }
    }
}