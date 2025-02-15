using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for UpDownTextblock.xaml
    /// </summary>
    public partial class UpDownTextblock : UserControl
    {
        public ViewModel _viewModel = new ViewModel();
        public UpDownTextblock()
        {
            DataContext = _viewModel;
            InitializeComponent();
        }

        public int Value
        {
            get
            {
                return (int)GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);
            }
        }

        public static DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(UpDownTextblock), typeMetadata: new PropertyMetadata(0, PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var upDown = d as UpDownTextblock;
            if (upDown != null)
            {
                upDown._viewModel.Data.Value = (int) e.NewValue;
            }
        }
    }
}
