using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CG_lab5_Ostapenko
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _imageSideLength;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateFigureButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _imageSideLength = int.Parse(ResolutionTextBox.Text);
            }
            catch
            {
                _imageSideLength = 500;
            }

            var bitmap = new WriteableBitmap(_imageSideLength + 10, _imageSideLength + 10, 96, 96, PixelFormats.Bgr32, null);
            ImageBox.Source = bitmap;
            var figure = CreateFigure();

            var drawer = new Drawer(bitmap, figure);
            drawer.DrawFigureLines();
            drawer.FillFigure();
        }

        private Figure CreateFigure()
        {
            Line[] lines =
            {
                new Line(
                    0,
                    _imageSideLength / 5 * 3,
                    0,
                    _imageSideLength / 5 * 2),

                new Line(
                    0,
                    _imageSideLength / 5 * 2,
                    _imageSideLength / 4 * 3,
                    _imageSideLength / 5 * 2),

                new Line(
                    0,
                    _imageSideLength / 5 * 3,
                    _imageSideLength / 4 * 3,
                    _imageSideLength / 5 * 3),

                new Line(
                    _imageSideLength / 4 * 3,
                    _imageSideLength / 5 * 2,
                    _imageSideLength / 4 * 3,
                    _imageSideLength / 3),

                new Line(
                    _imageSideLength / 4 * 3,
                    _imageSideLength / 5 * 3,
                    _imageSideLength / 4 * 3,
                    _imageSideLength / 3 * 2),

                new Line(
                    _imageSideLength / 4 * 3,
                    _imageSideLength / 3 * 2,
                    _imageSideLength,
                    _imageSideLength / 2),

                 new Line(
                    _imageSideLength / 4 * 3,
                    _imageSideLength / 3,
                    _imageSideLength,
                    _imageSideLength / 2)
            };

            return new Figure(lines);
        }
    }
}
