using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CG_lab2_Ostapenko
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _imageWidth;
        private int _imageHeight;
        private double err;

        private Figure rhombus;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateFigureButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _imageHeight = _imageWidth = int.Parse(ResolutionTextBox.Text);
            }
            catch
            {
                _imageHeight = _imageWidth = 1000;
            }

            var bitmap = new WriteableBitmap(_imageWidth, _imageHeight, 96, 96, PixelFormats.Bgr32, null);
            ImageBox.Source = bitmap;

            CreateFigure();

            for (int index = 0; index < rhombus.Lines.Length; index++)
            {
                err = - 1 / 2;
                double delta = (double)Math.Abs(rhombus.Lines[index].Y1 - rhombus.Lines[index].Y2) / (double)Math.Abs(rhombus.Lines[index].X1 - rhombus.Lines[index].X2);

                int y = (int)rhombus.Lines[index].Y1;
                int x = (int)rhombus.Lines[index].X1;

                while (y < rhombus.Lines[index].Y2 && x < rhombus.Lines[index].X2)
                {
                    FillPixel(bitmap, x, y);

                    err += delta;
                    if (err > 0)
                    {
                        y++;
                        err -= 1;
                    }

                    x++;
                }
            }
        }

        private void FillPixel(WriteableBitmap bitmap, int x, int y)
        {
            byte red = 255;
            byte green = 255;
            byte blue = 255;
            byte[] colorData = { blue, green, red, 255 };

            var rect = new Int32Rect(x, y, 1, 1);
            bitmap.WritePixels(rect, colorData, 4, 0);
        }

        private void CreateFigure()
        {
            Line[] lines =
            {
                new Line(0, _imageHeight / 2, _imageWidth / 2, 0),
                new Line(_imageWidth / 2, 0, _imageWidth, _imageHeight / 2),
                new Line(_imageWidth, _imageHeight / 2, _imageWidth / 2, _imageHeight),
                new Line(_imageWidth / 2, _imageHeight, 0, _imageHeight / 2)
            };

            rhombus = new Figure(lines);
        }
    }
}
