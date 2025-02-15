using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Diagnostics;

namespace EventRouting {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();

            this.MouseEnter += MouseEnterHandler;
            myBorder.MouseEnter += MouseEnterHandler;
            myPanel.MouseEnter += MouseEnterHandler;
            myEllipse.MouseEnter += MouseEnterHandler;
            myRectangle.MouseEnter += MouseEnterHandler;

            this.MouseDown += MouseDownHandler;
            myBorder.MouseDown += MouseDownHandler;
            myPanel.MouseDown += MouseDownHandler;
            myEllipse.MouseDown += MouseDownHandler;
            myRectangle.MouseDown += MouseDownHandler;

            this.PreviewMouseDown += PreviewMouseDownHandler;
            myBorder.PreviewMouseDown += PreviewMouseDownHandler;
            myPanel.PreviewMouseDown += PreviewMouseDownHandler;
            myEllipse.PreviewMouseDown += PreviewMouseDownHandler;
            myRectangle.PreviewMouseDown += PreviewMouseDownHandler;

            for (int i = 1; i <= 5; ++i) {
                Button btn = new Button();
                btn.Content = "Button " + i;
                myPanel.Children.Add(btn);

                btn.Click += new RoutedEventHandler(btn_Click);
            }

            // Ausnutzung des Bubbling
            // myPanel.Click ... gibts nicht - aber wir wissen, das Panel erhält das Event (wg. Bubbling)
            // Konzept der Attached Properties - wir attachen einen Handler für einen Eventd, er in einer anderen Klasse definiert wurde
            //myPanel.AddHandler(Button.ClickEvent, new RoutedEventHandler(btn_Click));
        }

        private void btn_Click(object sender, RoutedEventArgs e) {
            //Button btn = (Button) e.Source;
            Button btn = (Button) sender;
            btn.Background = Brushes.Green;
        }

        private void MouseEnterHandler(object sender, MouseEventArgs e) {
            Debug.WriteLine("MouseEnter: " + sender);
        }

        private void PreviewMouseDownHandler(object sender, MouseButtonEventArgs e) {
            Debug.WriteLine("PreviewMouseDown: " + sender);
            //e.Handled = true;
        }
        private void MouseDownHandler(object sender, MouseButtonEventArgs e) {
            Debug.WriteLine("MouseDown: " + sender);
            //e.Handled = true;
        }

    }
}
