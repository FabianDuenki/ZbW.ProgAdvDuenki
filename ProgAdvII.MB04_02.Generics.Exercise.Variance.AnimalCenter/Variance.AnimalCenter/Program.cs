namespace Variance.AnimalCenter {
    internal class Program {
        static void Main(string[] args) {
            // 1.
            var dogFeeder = new UniversalFeeder();
            IAnimalFeeder<Dog> feeder = dogFeeder; 

            // 2.
            var dogFactory = new DogFactory();
            IAnimalFactory<Animal> factory = dogFactory; 

            // 3.
            var pairer = new CatPairer();
            IAnimalPairer<Animal> genericPairer = pairer; 

            // 4a. 
            AnimalAction<Animal> logAnimal = animal => Console.WriteLine($"Logge: {animal.Name}");
            AnimalAction<Dog> dogLogger = logAnimal; 
            dogLogger(new Dog());

            // 4b. 
            AnimalFactory<Dog> dogCreator = () => new Dog();
            AnimalFactory<Animal> genericAnimalCreator = dogCreator; 
            Animal createdAnimal = genericAnimalCreator();
            Console.WriteLine($"Vom Delegate erzeugt: {createdAnimal.Name}");
        }
    }

    class UniversalFeeder : IAnimalFeeder<Animal> {
        public void Feed(Animal animal) => Console.WriteLine($"{animal.Name} bekommt Futter.");
    }

    class DogFactory : IAnimalFactory<Dog> {
        public Dog Create() => new Dog();
    }

    class CatPairer : IAnimalPairer<Cat> {
        public Cat Mate(Cat other) {
            Console.WriteLine("Zwei Katzen wurden verpaart.");
            return new Cat();
        }
    }

    // 4. Delegates mit Variance – klar, getrennt, verständlich

    // Kontravarianter Delegate: T ist Eingabe
    delegate void AnimalAction<T>(T animal);

    // Kovarianter Delegate: T ist Rückgabe
    delegate T AnimalFactory<T>();

    interface IAnimalFeeder<T> {
        void Feed(T animal);
    }

    interface IAnimalFactory<T> {
        T Create();
    }

    interface IAnimalPairer<T> {
        T Mate(T partner);
    }

    interface IAnimalEventSubscriber<T> {
        void Subscribe(Action<T> onEvent);
    }
}