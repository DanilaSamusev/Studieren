using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SSP_lab3
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

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var selectedItem = (ComboBoxItem)comboBox.SelectedItem;

            if (selectedItem.Content == null)
            {
                return;
            }

            this.Canvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(selectedItem.Content.ToString());
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;

            this.Canvas.DefaultDrawingAttributes.Width = e.NewValue;
            this.Canvas.DefaultDrawingAttributes.Height = e.NewValue;
        }

        private void DrawRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.Canvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void EditRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.Canvas.EditingMode = InkCanvasEditingMode.Select;
        }

        private void DeleteRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.Canvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
        }
    }
}
