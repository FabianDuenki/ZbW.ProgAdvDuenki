using System.Windows;
using System.Windows.Controls;

namespace BindingExample {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        Person src = new Person {Name = "Thomas", Age = 40.4};

        public Window1() {
            InitializeComponent();

            this.DataContext = src;
        }

        private void Button1_Click(object sender, RoutedEventArgs e) {
            string message = src.Name + " is " + src.Age;
            MessageBox.Show(message);
        }

        private void Button2_Click(object sender, RoutedEventArgs e) {
            src.Age += 0.1;

            //ageText.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
        }
    }
}
