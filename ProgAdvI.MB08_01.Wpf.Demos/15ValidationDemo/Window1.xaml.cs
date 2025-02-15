using System.Windows;
using System.Windows.Controls;

namespace Validation {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        MySource src = new MySource {Name = "Thomas", Age = 21};

        public Window1() {
            InitializeComponent();

            this.DataContext = src;
        }

        private void Window1_OnError(object sender, ValidationErrorEventArgs e) {
        }
    }
}
