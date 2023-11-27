using System.Windows;
using TreeViewDemo.ViewModels;

namespace TreeViewDemo
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        /// <summary>
        /// Initialize second window with MainViewModel
        /// </summary>
        public SecondWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        /// <summary>
        /// Return back to the last window and close this window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
