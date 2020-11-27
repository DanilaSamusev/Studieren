using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CG_lab5_Ostapenko
{
    class Drawer
    {
        private readonly WriteableBitmap _bitmap;
        private readonly Figure _figure;

        internal Drawer(WriteableBitmap bitmap, Figure figure)
        {
            _bitmap = bitmap;
            _figure = figure;
        }

        internal void DrawFigureLines()
        {
            var lines = _figure.Lines;
            for (int index = 0; index < lines.Length; index++)
            {
                double err = -(1.0 / 2.0);
                double delta = (double)Math.Abs(lines[index].Y1 - lines[index].Y2) / (double)Math.Abs(lines[index].X1 - lines[index].X2);

                int y;
                double y2;
                int x;
                double x2;

                if ((int)lines[index].X1 < lines[index].X2)
                {
                    x = (int)lines[index].X1;
                    x2 = lines[index].X2 + 1;
                    y = (int)lines[index].Y1;
                    y2 = lines[index].Y2;
                }
                else
                {
                    x2 = lines[index].X1;
                    x = (int)lines[index].X2;
                    y2 = lines[index].Y1;
                    y = (int)lines[index].Y2;
                }

                int xCrement = 1;
                int yCrement;

                if (x == x2)
                {
                    xCrement = 0;
                }

                Predicate<int> isLineEnded;

                if (y > y2)
                {
                    isLineEnded = (x) => (y <= y2 && x >= x2);
                    yCrement = -1;
                }
                else
                {
                    isLineEnded = (x) => (y >= y2 && x >= x2);
                    yCrement = 1;
                }

                do
                {
                    try
                    {
                        FillPixel(x, y);
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
                while (!isLineEnded(x));
            }
        }

        internal void FillFigure()
        {
            List<Point> points = _figure.GetCells().ToList<Point>();

            var maxX = points.Max(p => p.X);
            var rightPoint = points.FirstOrDefault(p => p.X == maxX);
            points.Remove(rightPoint);

            var minY = points.Min(p => p.Y);
            var topPoint = points.FirstOrDefault(p => p.Y == minY);
            points.Remove(topPoint);

            var maxY = points.Max(p => p.Y);
            var bottomPoint = points.FirstOrDefault(p => p.Y == maxY);
            points.Remove(bottomPoint);

            FillTriangle(rightPoint, topPoint, bottomPoint);

            minY = points.Min(p => p.Y);
            var minX = points.Min(p => p.X);
            maxY = points.Max(p => p.Y);
            maxX = points.Max(p => p.X);

            FillRectangle(minY, minX, maxY, maxX);
        }

        private void FillRectangle(double minY, double minX, double maxY, double maxX)
        {
            for (double line = minY; line < maxY; line++)
            {
                for (double column = minX; column <= maxX; column++)
                {
                    FillPixel((int)column, (int)line);
                }
            }
        }

        private void FillTriangle(Point rightPoint, Point topPoint, Point bottomPoint)
        {
            double k = Math.Abs((rightPoint.Y - topPoint.Y) / (rightPoint.X - topPoint.X));

            double verticalOffset = k;

            for (double column = rightPoint.X; column > topPoint.X; column--)
            {
                for (double line = rightPoint.Y - verticalOffset; line < rightPoint.Y + verticalOffset; line++)
                {
                    FillPixel((int)column, (int)line);
                }
                verticalOffset += k;
            }
        }

        private void FillPixel(int x, int y)
        {
            byte red = 255;
            byte green = 255;
            byte blue = 255;
            byte[] colorData = { blue, green, red, 255 };

            var rect = new Int32Rect(x, y, 1, 1);
            _bitmap.WritePixels(rect, colorData, 4, 0);
        }
    }
}
