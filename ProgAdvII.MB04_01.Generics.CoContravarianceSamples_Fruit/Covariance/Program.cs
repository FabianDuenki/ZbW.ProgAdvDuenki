// See https://aka.ms/new-console-template for more information


using Covariance;


Apple[] apples = new Apple[] { new Apple() { Weight = 100 }, new Apple() { Weight = 105 } };
Fruit[] fruits = apples;

var weightSum = 0m;
foreach(var fruit in fruits) {
    weightSum += fruit.Weight;

}   


fruits[1] = new Banana();



string[] strings = new string[] { "a", "b", "c" };

object[] objects = strings;

objects[1] = 5;




FirstSampleWithList();
//FirstSample();
//WithStandardGenerics();
//WithHomemadeGeneric();
//WithArrays();



void FirstSampleWithList() {

    List<Apple> apples = new List<Apple>();
    apples.Add(new Apple {Weight = 500});
    apples.Add(new Apple {Weight = 550});

    IEnumerable<Apple> covariantApples = apples;

   
    var totalApples = SumWeights(covariantApples); // Was könnte der Grund sein, dass das nicht geht?

    List<Banana> bananas = new List<Banana>();
    bananas.Add(new Banana { Weight = 800 });
    bananas.Add(new Banana { Weight = 790 });

    var totalBananas = SumWeights(bananas);
}

void FirstSample() {
    BagOfFruits fruits = new BagOfApples();
    fruits.Add(new Apple());
    fruits.Add(new Banana());

    Console.WriteLine(fruits.Get(0));
    Console.WriteLine(fruits.Get(1));

    BagOfApples apples = (BagOfApples)fruits;
    Console.WriteLine(apples.Get(0));
    Console.WriteLine(apples.Get(1));
}

decimal SumWeights(IEnumerable<Fruit> fruits) {
    var ret = 0m;
    foreach (var fruit in fruits) {
        ret += fruit.Weight;
    }

//    fruits.Add(new Banana());

    return ret;
}




void WithStandardGenerics() {
    var bagOfApples = new List<Apple>() {
        new(), new()
    };

    IEnumerable<Fruit> bagOfFruit;

    bagOfFruit = bagOfApples;

    foreach (Fruit fruit in bagOfFruit)
        Console.WriteLine(fruit);

    bagOfApples.Add(new Apple());

    Console.WriteLine("---");

    foreach (Fruit fruit in bagOfFruit)
        Console.WriteLine(fruit);

    //bagOfApples.Add(new Banana());
    //bagOfFruit.Add(new Banana ());

    Console.WriteLine("---");

    foreach (Fruit fruit in bagOfFruit)
        Console.WriteLine(fruit);
}

void WithHomemadeGeneric() {
    var bagOfApples = new Bag<Apple>();

    bagOfApples.Add(new Apple());
    bagOfApples.Add(new Apple());
    bagOfApples.Add(new Apple());

    IBag<Fruit> bagOfFruit = bagOfApples;

    Console.WriteLine(bagOfFruit.Get(0));
    Console.WriteLine(bagOfFruit.Get(1));

    //bagOfApples.Add(new Banana());
    //bagOfFruit.Add(new Banana());
}

void WithArrays() {
    var arrayOfApples = new Apple[] {
        new Apple(),
        new Apple(),
        new Apple()
    };

    Fruit[] arrayOfFruit = arrayOfApples;

    foreach (Fruit fruit in arrayOfFruit)
        Console.WriteLine(fruit);

    arrayOfFruit[1] = new Banana();

    foreach (Apple apple in arrayOfApples)
        Console.WriteLine(apple);
}


public interface ITest<out T> {
    //void Add(T item);

    T Get(int index);

    T Foo(int test);

    //T Foo2(T test);
}