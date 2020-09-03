using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MaxwellTriangle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int imageWidth;
        private int imageHeight;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateTriangleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                imageHeight = imageWidth = int.Parse(triangleSizeTextBox.Text);
            }
            catch
            {
                imageHeight = imageWidth = 1000;
            }

            var bitmap = new WriteableBitmap(imageWidth, imageHeight, 96, 96, PixelFormats.Bgr32, null);
            ImageBox.Source = bitmap;

            for (int line = 0; line < imageHeight; line++)
            {
                for (int column = 0; column < imageWidth; column++)
                {
                    if (IsPixelInTriangle(column, line))
                    {
                        byte red = GetRed(line);
                        byte green = GetGreen(column, line);
                        byte blue = GetBlue(column, line);
                        byte[] colorData = { blue, green, red, 255 };

                        var rect = new Int32Rect(column, line, 1, 1);
                        bitmap.WritePixels(rect, colorData, 4, 0);
                    }
                }
            }
        }

        private bool IsPixelInTriangle(int x, int y)
        {
            double tan60 = Math.Tan(Math.PI / 3);
            try
            {
                double first = (double)(imageHeight - y) / (double)x;
                double second = (double)(imageHeight - y) / (double)(imageWidth - x);

                return first <= tan60 && second <= tan60;
            }
            catch (DivideByZeroException ex)
            {
                return false;
            }
        }

        private byte GetRed(int y)
        {
            int red = imageHeight - y;

            if (red > byte.MaxValue)
            {
                return byte.MaxValue;
            }

            return (byte)red;
        }

        private byte GetGreen(int x, int y)
        {
            double hypotenuse = Math.Sqrt(Math.Pow(imageHeight - y, 2) + Math.Pow(x, 2));
            double firstAngle = Math.Acos(x / hypotenuse);
            double secondAngle = Math.PI / 3 - firstAngle;

            int green = (int)(hypotenuse * Math.Sin(secondAngle));

            if (green > byte.MaxValue)
            {
                return byte.MaxValue;
            }

            return (byte)green;
        }

        private byte GetBlue(int x, int y)
        {
            double hypotenuse = Math.Sqrt(Math.Pow(imageHeight - y, 2) + Math.Pow(imageWidth - x, 2));
            double firstAngle = Math.Acos((imageWidth - x) / hypotenuse);
            double secondAngle = Math.PI / 3 - firstAngle;

            int blue = (int)(hypotenuse * Math.Sin(secondAngle));
            
            if (blue > byte.MaxValue)
            {
                return byte.MaxValue;
            }

            return (byte)blue;
        }
    }
}
