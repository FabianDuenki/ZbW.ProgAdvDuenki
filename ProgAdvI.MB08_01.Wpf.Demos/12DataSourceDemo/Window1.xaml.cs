using System.Collections.Generic;
using System.Windows;

namespace BindingExample {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        Person src = new Person {Name = "Ian", Age = 34.6};

        //ObservableCollection<Person> people = new ObservableCollection<Person>();
        List<Person> people = new List<Person>();

        public Window1() {
            InitializeComponent();

            people.Add(src);
            people.Add(new Person {Name = "Mike", Age = 62.5});
            people.Add(new Person {Name = "Brian", Age = 3.5});

            this.DataContext = people;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            string message = src.Name + " is " + src.Age;
            MessageBox.Show(message);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            src.Age += 0.1;

            //ageText.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
        }

        int personId = 1;

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            people.Add(new Person {Name = "Person " + (personId++), Age = 0});
        }
    }
}