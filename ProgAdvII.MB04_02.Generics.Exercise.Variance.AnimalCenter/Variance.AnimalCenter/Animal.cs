namespace Variance.AnimalCenter {
    class Animal {
        public virtual string Name => "Tier";
    }

    class Dog : Animal {
        public override string Name => "Hund";
    }

    class Cat : Animal {
        public override string Name => "Katze";
    }
}
