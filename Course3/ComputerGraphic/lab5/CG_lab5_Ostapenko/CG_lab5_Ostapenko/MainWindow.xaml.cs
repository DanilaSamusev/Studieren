using System;
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
        private int _imageWidth;
        private int _imageHeight;
        private double err;

        private Figure rhombus;

        delegate bool ConditionCheker();

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
                _imageHeight = _imageWidth = 500;
            }

            var bitmap = new WriteableBitmap(_imageWidth + 10, _imageHeight + 10, 96, 96, PixelFormats.Bgr32, null);
            ImageBox.Source = bitmap;

            CreateFigure();

            for (int index = 0; index < rhombus.Lines.Length; index++)
            {
                err = -(1.0 / 2.0);
                double delta = (double)Math.Abs(rhombus.Lines[index].Y1 - rhombus.Lines[index].Y2) / (double)Math.Abs(rhombus.Lines[index].X1 - rhombus.Lines[index].X2);

                int y;
                double y2;
                int x;
                double x2;

                if ((int)rhombus.Lines[index].X1 < rhombus.Lines[index].X2)
                {
                    x = (int)rhombus.Lines[index].X1;
                    x2 = rhombus.Lines[index].X2;
                    y = (int)rhombus.Lines[index].Y1;
                    y2 = rhombus.Lines[index].Y2;
                }
                else
                {
                    x2 = rhombus.Lines[index].X1;
                    x = (int)rhombus.Lines[index].X2;
                    y2 = rhombus.Lines[index].Y1;
                    y = (int)rhombus.Lines[index].Y2;
                }

                ConditionCheker isLineEnded;

                int xCrement = 1;
                int yCrement;

                if (x == x2)
                {
                    xCrement = 0;
                }

                if (y > y2)
                {
                    isLineEnded = () => y <= y2 && x >= x2;
                    yCrement = -1;
                }
                else
                {
                    isLineEnded = () => y >= y2 && x >= x2;
                    yCrement = 1;
                }

                while (!isLineEnded())
                {
                    try
                    {
                        FillPixel(bitmap, x, y);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        break;
                    }

                    err += delta;
                    if (err > 0)
                    {
                        y += yCrement;
                        err--;
                    }

                    x += xCrement;
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
                new Line(
                    0,
                    _imageHeight / 5 * 3,
                    0,
                    _imageHeight / 5 * 2),

                new Line(
                    0,
                    _imageHeight / 5 * 2,
                    _imageWidth / 4 * 3,
                    _imageHeight / 5 * 2),

                new Line(
                    0,
                    _imageHeight / 5 * 3,
                    _imageWidth / 4 * 3,
                    _imageHeight / 5 * 3),

                new Line(
                    _imageWidth / 4 * 3,
                    _imageHeight / 5 * 2,
                    _imageWidth / 4 * 3,
                    _imageHeight / 3),

                new Line(
                    _imageWidth / 4 * 3,
                    _imageHeight / 5 * 3,
                    _imageWidth / 4 * 3,
                    _imageHeight / 3 * 2),

                new Line(
                    _imageWidth / 4 * 3,
                    _imageHeight / 3 * 2,
                    _imageWidth,
                    _imageHeight / 2),

                 new Line(
                    _imageWidth / 4 * 3,
                    _imageHeight / 3,
                    _imageWidth,
                    _imageHeight / 2)
            };

            rhombus = new Figure(lines);
        }
    }
}
