using System;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;

namespace CommandHandling {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();

            //// CommandBinding verbindet den Command mit einem Handler
            //CommandBinding copyCommand = new CommandBinding(ApplicationCommands.Copy);
            //this.CommandBindings.Add(copyCommand);
            //copyCommand.Executed += new ExecutedRoutedEventHandler(CopyCommandOnExecuted);
            //copyCommand.CanExecute += new CanExecuteRoutedEventHandler(CopyCommandOnCanExecute);
        }

        private void CopyCommandOnCanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = true;
        }

        void CopyCommandOnExecuted(object sender, ExecutedRoutedEventArgs e) {
            Debug.WriteLine("Copy executed");
        }
    }
}
