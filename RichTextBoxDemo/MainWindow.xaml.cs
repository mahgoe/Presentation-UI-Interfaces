using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace RichTextBoxDemo
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
        /// Makes the text bold.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bold_Click(object sender, RoutedEventArgs e)
        {
            var isChecked = btnBold.IsChecked ?? false;
            EditingCommands.ToggleBold.Execute(null, richTextBox);
            btnBold.Background = isChecked ? Brushes.Blue : Brushes.Transparent;
        }

        /// <summary>
        /// Makes the text emphasised
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Italic_Click(object sender, RoutedEventArgs e)
        {
            var isChecked = btnItalic.IsChecked ?? false;
            EditingCommands.ToggleItalic.Execute(null, richTextBox);
            btnItalic.Background = isChecked ? Brushes.Blue : Brushes.Transparent;
        }

        /// <summary>
        /// Makes the text underlined
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Underline_Click(object sender, RoutedEventArgs e)
        {
            var isChecked = btnUnderline.IsChecked ?? false;
            EditingCommands.ToggleUnderline.Execute(null, richTextBox);
            btnUnderline.Background = isChecked ? Brushes.Blue : Brushes.Transparent;
        }

        /// <summary>
        /// Changes the font size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontSizeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                var newFontSize = Convert.ToDouble(selectedItem.Content);

                var currentWeight = richTextBox.Selection.GetPropertyValue(TextElement.FontWeightProperty);
                var currentStyle = richTextBox.Selection.GetPropertyValue(TextElement.FontStyleProperty);
                var currentDecorations = richTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);

                if (richTextBox.Selection.IsEmpty)
                {
                    var run = new Run()
                    {
                        FontSize = newFontSize,
                        FontWeight = (FontWeight)currentWeight,
                        FontStyle = (FontStyle)currentStyle,
                        TextDecorations = (TextDecorationCollection)currentDecorations
                    };

                    var para = richTextBox.CaretPosition.Paragraph;
                    if (para != null)
                    {
                        para.Inlines.Add(run);
                        richTextBox.CaretPosition = run.ElementStart;
                    }
                }
                else
                {
                    richTextBox.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, newFontSize);
                }

                richTextBox.Focus();

                if (richTextBox.Selection.IsEmpty)
                {
                    richTextBox.CaretPosition.Paragraph.FontWeight = (FontWeight)currentWeight;
                    richTextBox.CaretPosition.Paragraph.FontStyle = (FontStyle)currentStyle;
                    richTextBox.CaretPosition.Paragraph.TextDecorations = (TextDecorationCollection)currentDecorations;
                }
            }
        }

        /// <summary>
        /// Search a word/phrase from the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text;
            if (string.IsNullOrEmpty(searchText))
            {
                return;
            }

            TextRange searchRange = new TextRange(
                richTextBox.Document.ContentStart,
                richTextBox.Document.ContentEnd);

            // Clear previous highlights
            ClearHighlights(searchRange);

            TextPointer current = searchRange.Start.GetInsertionPosition(LogicalDirection.Forward);
            while (current != null)
            {
                string textInRun = current.GetTextInRun(LogicalDirection.Forward);
                if (!string.IsNullOrWhiteSpace(textInRun))
                {
                    int index = textInRun.IndexOf(searchText, StringComparison.OrdinalIgnoreCase);
                    if (index != -1)
                    {
                        TextPointer selectionStart = current.GetPositionAtOffset(index, LogicalDirection.Forward);
                        TextPointer selectionEnd = selectionStart.GetPositionAtOffset(searchText.Length, LogicalDirection.Forward);
                        TextRange selectionRange = new TextRange(selectionStart, selectionEnd);
                        selectionRange.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(Colors.Yellow));
                    }
                }
                current = current.GetNextContextPosition(LogicalDirection.Forward);
            }

        }

        /// <summary>
        /// Clears highlights and searchbar on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = String.Empty;

            TextRange searchRange = new TextRange(
                 richTextBox.Document.ContentStart,
                 richTextBox.Document.ContentEnd);
            ClearHighlights(searchRange);

            SearchTextBox.Text = String.Empty;
        }

        /// <summary>
        /// Logic to clear highlights
        /// </summary>
        /// <param name="searchRange"></param>
        private void ClearHighlights(TextRange searchRange)
        {
            searchRange.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(Colors.White));
        }

    }
}
