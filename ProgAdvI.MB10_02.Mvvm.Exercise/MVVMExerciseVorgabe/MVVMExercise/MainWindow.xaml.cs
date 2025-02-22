using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfExercise {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private Datasource.Data Data { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            this.Data = Datasource.Data.Load();
            this.listbox.ItemsSource = this.Data.Customers.CustomerList;
            this.listbox.SelectedItem = this.Data.Customers.CustomerList[0];
        }

        private void Close_Click(object sender, RoutedEventArgs e) {
            this.Data.Save();
            this.Close();
        }


        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var lb = (ListBox) sender;
            this.DataContext = lb.SelectedItem;
        }
    }
}
