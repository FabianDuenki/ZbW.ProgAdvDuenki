using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfDemo {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            var binding = new Binding {Source = new Vector(1, 2, 4)};
            this.myTextBlock1.SetBinding(TextBlock.TextProperty, binding);

            binding = new Binding {Source = new Vector(1, 2, 4), Path= new PropertyPath("X")};
            this.myTextBlock2.SetBinding(TextBlock.TextProperty, binding);
        }
    }

    struct Vector { 
        public Vector(double x, double y, double z) {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X { get; }
        public double Y { get; }
        public double Z { get; }
        public override string ToString() {
            return "[" + this.X + " " + this.Y + " " + this.Z + "]";
        }
    }
}
