using System;

namespace CoContraVariance {
    class GeometricObject { }

    class Circle : GeometricObject { }

    delegate GeometricObject CovarianceHandler();

    delegate void ContravarianceHandler(Circle circle);

    class Program {
        static void Main(string[] args) {
            CovarianceHandler handler = DoSomething;
            GeometricObject geo = handler();
            Console.WriteLine(geo.GetType());
            Console.ReadLine();

            //ContravarianceHandler handler = DoSomething;
            //handler(new Circle());
            //Console.ReadLine();
        }

        public static Circle DoSomething() {
            return new Circle();
        }

        //public static void DoSomething(GeometricObject geo) {
        //    Console.WriteLine(geo.GetType());
        //}
    }
}