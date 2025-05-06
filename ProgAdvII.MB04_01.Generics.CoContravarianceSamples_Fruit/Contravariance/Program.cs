namespace Contravariance {
    internal class Program {
        public static void Main(string[] args) {

            FirstExample();
            //ProcessFruits();
        }

        static void FirstExample() {
            var appleAction = new MyAction<Apple>(a => Console.WriteLine($"Weight of Apple: {a.Weight}"));
            PerformAppleAction(appleAction);

            var bananaAction = new MyAction<Banana>(b => Console.WriteLine($"Weight of Banana: {b.Weight}"));
            PerformAppleAction(bananaAction);

            var fruitAction = new MyAction<Fruit>(f => Console.WriteLine($"Weight of Fruit: {f.Weight}"));
            PerformAppleAction(fruitAction);
        }

        static void PerformAppleAction(MyAction<Apple> action) {
            var apple = new Apple { Weight = 600 };
            action(apple);
        }

        static void ProcessFruits() {
            IProcessor<Fruit> fruitProcessor = new FruitProcessor();

            IProcessor<Apple> appleProcessor = fruitProcessor;
            IProcessor<Banana> bananaProcessor = fruitProcessor;

            // Verarbeite Apfel und Banane mit demselben FruitProcessor
            appleProcessor.Process(new Apple());
            bananaProcessor.Process(new Banana());
        }
    }


    delegate void MyAction<T>(T obj);


    interface IProcessor<T> {
        void Process(T input);
    }

    // Verarbeitet alle Früchte
    public class FruitProcessor : IProcessor<Fruit> {
        public void Process(Fruit fruit) {
            Console.WriteLine($"Verarbeite {fruit.Name} zu Saft.");
        }
    }

    public interface MyEnumerable<out T> {
        T GetElementAt(int index);

        //void AddElement(T element);
    }
}