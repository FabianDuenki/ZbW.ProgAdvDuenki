using System.Windows;
using System.Windows.Media;

namespace ResourceReferences {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
        }

        private void changeResourceButton_Click(object sender, RoutedEventArgs e) {
            this.Resources["brushResource"] = Brushes.Red;
        }
    }
}
