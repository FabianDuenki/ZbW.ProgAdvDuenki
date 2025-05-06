namespace Covariance {
    public class Fruit {
        public decimal Weight { get; set; }
    }

    public class Apple : Fruit {
        public override string ToString() {
            return "Apple";
        }
    }

    public class Banana : Fruit {
        public override string ToString() {
            return "Banana";
        }
    }
}