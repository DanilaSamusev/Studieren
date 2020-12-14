using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        Bitmap g = new Bitmap(500, 500);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private static void PutPixel(Bitmap bmp, Color col, int x, int y, int alpha)
        {
            bmp.SetPixel(x, y, col);
        }

        public static void Bres(Bitmap g, Color clr, int x0, int y0, int x1, int y1)
        {

            int dx = (x1 > x0) ? (x1 - x0) : (x0 - x1); 
            int dy = (y1 > y0) ? (y1 - y0) : (y0 - y1);

            int sx = (x1 >= x0) ? (1) : (-1);  
            int sy = (y1 >= y0) ? (1) : (-1);

            if (dy < dx)
            {
                int inaccuracy = (dy << 1) - dx;
                int d1 = dy << 1;
                int d2 = (dy - dx) << 1;
                PutPixel(g, clr, x0, y0, 255);
                int x = x0 + sx;
                int y = y0;
                for (int i = 1; i <= dx; i++)
                {
                    if (inaccuracy > 0)
                    {
                        inaccuracy += d2;
                        y += sy;
                    }
                    else
                        inaccuracy += d1;
                    PutPixel(g, clr, x, y, 255);
                    x += sx;
                }
            }
            else
            {
                int inaccuracy = (dx << 1) - dy;
                int d1 = dx << 1;
                int d2 = (dx - dy) << 1;
                PutPixel(g, clr, x0, y0, 255);
                int x = x0;
                int y = y0 + sy;
                for (int i = 1; i <= dy; i++)
                {
                    if (inaccuracy > 0)
                    {
                        inaccuracy += d2;
                        x += sx;
                    }
                    else
                        inaccuracy += d1;
                    PutPixel(g, clr, x, y, 255);
                    y += sy;
                }
            }
        }


        private void DrawFigure(Bitmap bmp)
        {
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Black);

            Bres(g, Color.Black, 20, 100, 70, 50);
            Bres(g, Color.Black, 70, 50, 120, 100);
             int x1 = 20; int y1 = 100; int x2 = 50; int y2 = 100;
            graph.DrawLine(pen, x1, y1, x2, y2);
            x1 = 120; y1 = 100; x2 = 90; y2 = 100;
            graph.DrawLine(pen, x1, y1, x2, y2);
            x1 = 50; y1 = 100; x2 = 50; y2 = 150;
            graph.DrawLine(pen, x1, y1, x2, y2);
            x1 = 90; y1 = 100; x2 = 90; y2 = 150;
            graph.DrawLine(pen, x1, y1, x2, y2);
            pictureBox1.Image = g;

        }


        public void DIZERING()
        {

            for (int stroka = 50; stroka <= 60; stroka += 5)
            {
                for (int stolbez = 1; stolbez <= 254; stolbez += 5)
                {
                    if (stolbez >= array[stroka, 0] && array[stroka, 1] >= stolbez)
                    {
                        plott_color(stolbez, stroka, Color.Black);
                    }
                }
            }
            for (int stroka = 61; stroka <= 80; stroka += 5)
            {
                for (int stolbez = 1; stolbez <= 254; stolbez += 5)
                {
                    if (stolbez >= array[stroka, 0] && array[stroka, 1] >= stolbez)
                    {
                        plott_color(stolbez, stroka, Color.Black);
                        plott_color(stolbez + 1, stroka + 1, Color.Black);
                    }
                }
            }
            for (int stroka = 81; stroka <= 100; stroka += 5)
            {
                for (int stolbez = 1; stolbez <= 254; stolbez += 5)
                {
                    if (stolbez >= array[stroka, 0] && array[stroka, 1] >= stolbez)
                    {
                        plott_color(stolbez, stroka+1, Color.Black);
                        plott_color(stolbez +1, stroka +1, Color.Black);
                    }
                }
            }
            for (int stroka = 101; stroka <= 120; stroka += 5)
            {
                for (int stolbez = 1; stolbez <= 254; stolbez += 5)
                {
                    if (stolbez >= array[stroka, 0] && array[stroka, 1] >= stolbez)
                    {
                        plott_color(stolbez+1, stroka + 1, Color.Black);
                        plott_color(stolbez + 1, stroka + 1, Color.Black); ;
                    }
                }
            }
            for (int stroka = 121; stroka <= 140; stroka += 5)
            {
                for (int stolbez = 1; stolbez <= 254; stolbez += 5)
                {
                    if (stolbez >= array[stroka, 0] && array[stroka, 1] >= stolbez)
                    {
                        plott_color(stolbez, stroka, Color.Black);
                        plott_color(stolbez+1 , stroka + 1, Color.Black);
                        plott_color(stolbez + 1, stroka+1, Color.Black);
                        plott_color(stolbez + 1, stroka +1, Color.Black);
                        
                    }
                }
            }
            for (int stroka = 141; stroka <= 180; stroka++)
            {
                for (int stolbez = 1; stolbez <= 254; stolbez++)
                {
                    if (stolbez >= array[stroka, 0] && array[stroka, 1] >= stolbez)
                    {
                        plott_color(stolbez, stroka, Color.Black);
                    }
                }
            }
        }
        public int[,] array = new int[181, 2];
       private void FillFigure()
        {
            int x1 = 0, x2 = 0;
            for (int i = 50; i <= 150; i++)
            {
                for (int j = 20; j <= 120; j++)
                {
                    if (areCVE(g.GetPixel(j, i), g.GetPixel(20, 100)) && x1 == 0)
                    {
                        x1 = j + 1;
                        array[i, 0] = j;
                    }
                    if (areCVE(g.GetPixel(j, i), g.GetPixel(20, 100)) && x1 != 0)
                    {
                        x2 = j - 1;
                        array[i, 1] = j;
                    }
                }
                x1 = 0; x2 = 0;
            }
        }

        private bool areCVE(Color clr1, Color clr2)
        {
            return (clr1.ToArgb() == clr2.ToArgb());
        }

        void plott_color(int XX, int YY, Color color)
        {
            if (XX >= 1 & YY >= 1 & XX <= 256 & YY <= 256)
            {
                g.SetPixel(XX, YY, color);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DrawFigure(g);
          FillFigure(); 
            DIZERING();
            pictureBox1.Image = g;
        }
    }
}
