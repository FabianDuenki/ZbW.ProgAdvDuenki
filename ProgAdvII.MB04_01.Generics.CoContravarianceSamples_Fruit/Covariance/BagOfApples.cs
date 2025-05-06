namespace Covariance {
    public class BagOfApples : BagOfFruits {
        public void Add(Apple apple) {
            base.Add(apple);
        }

        public Apple Get(int idx) {
            return (Apple)base.Get(idx);
        }
    }
}
