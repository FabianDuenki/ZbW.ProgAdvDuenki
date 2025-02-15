using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StyleDemo {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow5 : Window {
        public MainWindow5() {
            InitializeComponent();
        }

        private void lst_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ListBox listbox = sender as ListBox;
            txtSelection.Text = ((ListBoxItem)listbox.SelectedItem).Content.ToString();
        }

        private void lstCities_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            MessageBox.Show("Auswahl 'City'");
        }
    }
}
