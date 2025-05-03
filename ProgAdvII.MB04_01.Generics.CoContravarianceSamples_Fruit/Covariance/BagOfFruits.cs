namespace Covariance {
    public class BagOfFruits {
        private List<Fruit> fruits = new List<Fruit>();

        public void Add(Fruit fruit) {
            this.fruits.Add(fruit);
        }

        public Fruit Get(int idx) {
            return this.fruits[idx];
        }
    }
}
