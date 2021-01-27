using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KGlab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DrawCDA();
        }
        public void DrawCDA()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Black);

            int x1 = 200, y1 = 100, x2 = 100, y2 = 200;
            int longs;
            double x = x1;
            double y = y1;

            if (Math.Abs(x2 - x1) <= Math.Abs(y2 - y1))
            {
                longs = Math.Abs(x2 - x1);
            }
            else
            {
                longs = Math.Abs(y2 - y1);
            }
            double dx = (x2 - x1) / longs;
            double dy = (y2 - y1) / longs;

            for (int i = 0; i <= longs; i++)
            {
                bmp.SetPixel((int)x, (int)y, Color.Black);
                x += dx;
                y += dy;
            }



            x1 = 100;
            y1 = 200;
            x2 = 180;
            y2 = 200;
            graph.DrawLine(pen, x1, y1, x2, y2);


            x1 = 180;
            y1 = 200;
            x2 = 180;
            y2 = 300;
            graph.DrawLine(pen, x1, y1, x2, y2);


            x1 = 180;
            y1 = 300;
            x2 = 220;
            y2 = 300;
            graph.DrawLine(pen, x1, y1, x2, y2);

            x1 = 220;
            y1 = 300;
            x2 = 220;
            y2 = 200;
            graph.DrawLine(pen, x1, y1, x2, y2);


            x1 = 220;
            y1 = 200;
            x2 = 300;
            y2 = 200;
            graph.DrawLine(pen, x1, y1, x2, y2);


            x1 = 300;
            y1 = 200;
            x2 = 200;
            y2 = 100;
            x = x1;
            y = y1;
            if (Math.Abs(x2 - x1) <= Math.Abs(y2 - y1))
            {
                longs = Math.Abs(x2 - x1);
            }
            else
            {
                longs = Math.Abs(y2 - y1);
            }
            dx = (x2 - x1) / longs;
            dy = (y2 - y1) / longs;
            for (int i = 0; i <= longs; i++)
            {
                bmp.SetPixel((int)x, (int)y, Color.Black);
                x += dx;
                y += dy;
            }
            for (int yscan = 102; yscan <= 299; yscan++)
            {
                bool finishleft = false;
                bool finishright = false;
                for (int xscan = 201; finishleft == false; xscan--)
                {
                    if (bmp.GetPixel(xscan - 1, yscan) != bmp.GetPixel(0, 0))

                    {
                        bmp.SetPixel(xscan, yscan, Color.Blue);
                        finishleft = true;

                    }
                    else
                    {
                        bmp.SetPixel(xscan, yscan, Color.Blue);
                    }

                }
                finishleft = false;
                for (int xscan = 201; finishright == false; xscan++)
                {
                    if (bmp.GetPixel(xscan + 1, yscan) != bmp.GetPixel(0, 0))
                    {
                        bmp.SetPixel(xscan, yscan, Color.Blue);
                        finishright = true;

                    }
                    else
                    {
                        bmp.SetPixel(xscan, yscan, Color.Blue);
                    }
                }
                finishright = false;
            }
            pictureBox1.Image = bmp;
        }
    }
}
