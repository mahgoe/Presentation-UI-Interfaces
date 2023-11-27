using System.Windows;
using System.Windows.Controls;

namespace ListViewDemo
{
    /// <summary>
    /// Interaction logic for ThirdWindow.xaml
    /// </summary>
    public partial class ThirdWindow : Window
    {
        public ThirdWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Add new item to the ListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var newItem = TextInput.Text;
            List.Items.Add(new ListViewItem { Content = newItem });
        }

        /// <summary>
        /// Return back to the last window and close this window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow secondWindow = new SecondWindow();
            secondWindow.Show();
            this.Close();
        }
    }
}
