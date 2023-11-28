using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace ToggleButtonDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// If togglebutton active, change background color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var toggleButton = sender as ToggleButton;
            if (toggleButton.IsChecked == true)
            {
                this.Background = new SolidColorBrush(Colors.LightGreen);
            }
            else
            {
                this.Background = new SolidColorBrush(Colors.White);
            }
        }

        /// <summary>
        /// If toggle visible/invisible the box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisibilityToggle_Click(object sender, RoutedEventArgs e)
        {
            toggleTextBlock.Visibility = visibilityToggle.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
