using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraficLib;

namespace Lab12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bool IsRotating = false;
            double OXRotatingAngle = Math.PI / 4;
            double OZRotatingAngle = Math.PI / 18;


            double zoom = 3;
            Bitmap bmp = new Bitmap((int)(pictureBox1.Width * zoom), (int)(pictureBox1.Height * zoom));
            int lengthX = (int)(180 * zoom);
            int lengthY = (int)(220 * zoom);
            int height = (int)(60 * zoom);
            int cubeLength = (int)(150 * zoom);
            Point3D a = new Point3D(100 * zoom, 0 * zoom, 130 * zoom);
            Point3D a1 = new Point3D(a.X, a.Y, a.Z + height);
            Point3D b = new Point3D(a.X + lengthX, a.Y, a.Z);
            Point3D b1 = new Point3D(b.X, b.Y, b.Z + height);
            Point3D b2 = new Point3D(b1.X, b1.Y + lengthY / 2, b1.Z);
            Point3D c = new Point3D(b.X, b.Y + lengthY, b.Z);
            Point3D c1 = new Point3D(c.X, c.Y, c.Z + height / 2);
            Point3D d = new Point3D(a.X, a.Y + lengthY, a.Z);
            Point3D d1 = new Point3D(d.X, d.Y, d.Z + height);
            Point3D d2 = new Point3D(d1.X + lengthX / 2, d1.Y, d1.Z);

            Polygon3D[] polygons = new Polygon3D[]
            {
                new Polygon3D(new Point3D[] { a1,b1,b2,d2,d1 }){Color = Color.Red},
                new Polygon3D(new Point3D[] { a,b,c,d }){Color = Color.Red},
                new Polygon3D(new Point3D[] { a,b,b1,a1 }){Color = Color.Red},
                new Polygon3D(new Point3D[] { b,c,c1,b2,b1 }){Color = Color.Red},
                new Polygon3D(new Point3D[] { c,d,d1,d2,c1 }){Color = Color.Red},
                new Polygon3D(new Point3D[] { a,d,d1,a1 }){Color = Color.Red},
                 new Polygon3D(new Point3D[] { c1,d2,b2 }){Color = Color.Red},
            };

            Polyhedron polyhedron = new Polyhedron(polygons, a, b, c, d, a1, b1, c1, d1, d2, b2);
            //polyhedron = GetCone(30, (int)(40 * zoom), height); //конус
            //polyhedron = GetСylinder(30, (int)(40 * zoom), height); //цилиндр

            #region повороты
            var center2D = new Point2D(polyhedron.Center.X, polyhedron.Center.Y);


            foreach (var point in polyhedron.Vertexes)
            {
                var point2d = Grafic.Rotation(center2D, new Point2D(point.X, point.Y), OZRotatingAngle);
                point.X = point2d.X;
                point.Y = point2d.Y;
            }


            center2D = new Point2D(polyhedron.Center.Y, polyhedron.Center.Z);
            foreach (var point in polyhedron.Vertexes)
            {
                var point2d = Grafic.Rotation(center2D, new Point2D(point.Y, point.Z), OXRotatingAngle);
                point.Y = point2d.X;
                point.Z = point2d.Y;
            }
            #endregion

            foreach (var point in polyhedron.Vertexes)
            {
                double dx = (bmp.Width / 2) - polyhedron.Center.X;
                double dz = (bmp.Height / 2) - polyhedron.Center.Z;
                point.X += dx;
                point.Z += dz;
            } //ставим в центр            

           

            Task.Factory.StartNew(() =>
            {
                do
                {
                    try
                    {
                        bmp = new Bitmap(bmp.Width, bmp.Height);
                        DrawPolyhedronByPhong(bmp, polyhedron, new Vector(0, -1, 0), 1);
                        pictureBox1.Image = bmp;
                    }
                    catch (Exception)
                    { }

                    center2D = new Point2D(polyhedron.Center.Y, polyhedron.Center.Z);
                    foreach (var point in polyhedron.Vertexes)
                    {
                        var point2d = Grafic.Rotation(center2D, new Point2D(point.Y, point.Z), -OXRotatingAngle);
                        point.Y = point2d.X;
                        point.Z = point2d.Y;
                    }

                    center2D = new Point2D(polyhedron.Center.X, polyhedron.Center.Y);
                    foreach (var point in polyhedron.Vertexes)
                    {
                        var point2d = Grafic.Rotation(center2D, new Point2D(point.X, point.Y), OZRotatingAngle);
                        point.X = point2d.X;
                        point.Y = point2d.Y;
                    }

                    center2D = new Point2D(polyhedron.Center.Y, polyhedron.Center.Z);
                    foreach (var point in polyhedron.Vertexes)
                    {
                        var point2d = Grafic.Rotation(center2D, new Point2D(point.Y, point.Z), OXRotatingAngle);
                        point.Y = point2d.X;
                        point.Z = point2d.Y;
                    }
                } while (IsRotating);
            });
        }

        private void DrawPolyhedronByPhong(Bitmap bmp, Polyhedron polyhedron, Vector lightPoint, double p)
        {
            polyhedron.ResetBodyMatrix(polyhedron.Center);

            double[,] ZBuffer = new double[bmp.Width, bmp.Height];
            for (int y = 0; y < ZBuffer.GetLength(1) - 1; y++)
                for (int x = 0; x < ZBuffer.GetLength(0) - 1; x++)
                {
                    ZBuffer[x, y] = double.NegativeInfinity;
                }

            for (int polygon = 0; polygon < polyhedron.Faces.Length; polygon++)
            {
                double[] coef = polyhedron.Faces[polygon].CalculateCoefficients(new Point3D(0, 0, 0));
                double[] coef1 = polyhedron.Faces[polygon].CalculateCoefficients(polyhedron.Center);
                for (int i = 0; i < 4; i++)
                {
                    coef1[i] *= Math.Sign(coef1[3]);
                }

                Point3D[] pointsBuf = new Point3D[polyhedron.Faces[polygon].Points.Length + 1];
                polyhedron.Faces[polygon].Points.CopyTo(pointsBuf, 0);

                pointsBuf[pointsBuf.Length - 1] = pointsBuf[0];

                Vector[] VforPoints = new Vector[pointsBuf.Length];
                for (int i = 0; i < VforPoints.Length - 1; i++)
                {
                    var polygons = polyhedron.Faces.ToList().FindAll(x => x.Points.Contains(pointsBuf[i])); // грани, которым пренадлежит точка pointsBuf[i]
                    Vector normal = new Vector();
                    for (int k = 0; k < polygons.Count; k++)
                    {
                        int index = polyhedron.Faces.ToList().IndexOf(polygons[k]);
                        normal.X += polyhedron.BodyMatrix[0, index];
                        normal.Y += polyhedron.BodyMatrix[1, index];
                        normal.Z += polyhedron.BodyMatrix[2, index];
                    }
                    normal.X /= polygons.Count;
                    normal.Y /= polygons.Count;
                    normal.Z /= polygons.Count;

                    VforPoints[i] = normal;
                }
                VforPoints[VforPoints.Length - 1] = VforPoints[0];

                List<Tuple<Point3D, Point3D, Vector, Vector>> CAP = new List<Tuple<Point3D, Point3D, Vector, Vector>>();
                int ymin = (int)Math.Round(pointsBuf.Min(point => point.Z));
                int ymax = (int)Math.Round(pointsBuf.Max(point => point.Z));
                for (int y = ymin; y < ymax; y++)
                {
                    CAP.Clear();
                    for (int i = 1; i < pointsBuf.Length; i++)
                    {
                        int a = (int)Math.Min(pointsBuf[i].Z, pointsBuf[i - 1].Z);
                        int b = (int)Math.Max(pointsBuf[i].Z, pointsBuf[i - 1].Z);

                        bool IsActive = a < y && b >= y && a != b;
                        if (y == ymin)
                        {
                            IsActive = a <= y && b >= y && a != b;
                        }
                        if (IsActive)
                        {
                            CAP.Add(new Tuple<Point3D, Point3D, Vector, Vector>(pointsBuf[i], pointsBuf[i - 1], VforPoints[i], VforPoints[i - 1]));
                        }
                    }

                    try
                    {
                        int xmin = Math.Min(CalculateX(CAP[0].Item1, CAP[0].Item2, y), CalculateX(CAP[1].Item1, CAP[1].Item2, y));
                        int xmax = Math.Max(CalculateX(CAP[0].Item1, CAP[0].Item2, y), CalculateX(CAP[1].Item1, CAP[1].Item2, y));

                        double Ya;
                        double Yb;
                        double Yc;
                        double Yd;
                        Vector Va;
                        Vector Vb;
                        Vector Vc;
                        Vector Vd;
                        Tuple<Point3D, Point3D, Vector, Vector> left = CAP[1];
                        Tuple<Point3D, Point3D, Vector, Vector> right = CAP[0];

                        if (CalculateX(CAP[0].Item1, CAP[0].Item2, y) < CalculateX(CAP[1].Item1, CAP[1].Item2, y))
                        {
                            left = CAP[0];
                            right = CAP[1];
                        }
                        if (right.Item1.Z > right.Item2.Z)
                        {
                            Ya = right.Item1.Z;
                            Va = right.Item3;
                            Yb = right.Item2.Z;
                            Vb = right.Item4;
                        }
                        else
                        {
                            Ya = right.Item2.Z;
                            Va = right.Item4;
                            Yb = right.Item1.Z;
                            Vb = right.Item3;
                        }

                        if (left.Item1.Z > left.Item2.Z)
                        {
                            Yd = left.Item1.Z;
                            Vd = left.Item3;
                            Yc = left.Item2.Z;
                            Vc = left.Item4;
                        }
                        else
                        {
                            Yd = left.Item2.Z;
                            Vd = left.Item4;
                            Yc = left.Item1.Z;
                            Vc = left.Item3;
                        }

                        Vector V1 = Vd + (Vc - Vd) * (y - Yd) / (Yc - Yd);
                        Vector V2 = Va + (Vb - Va) * (y - Ya) / (Yb - Ya);

                        for (int x = xmin; x < xmax; x++)
                        {
                            Vector V = V1 + (V2 - V1) * (x - xmin) / (xmax - xmin);
                            double I = Math.Pow(GetCos(V, lightPoint), p);
                            int R = (int)(polyhedron.Faces[polygon].Color.R * I);
                            R = R > 0 && R < 255 ? R : R > 0 ? 255 : 0;
                            int G = (int)(polyhedron.Faces[polygon].Color.G * I);
                            G = G > 0 && G < 255 ? G : G > 0 ? 255 : 0;
                            int B = (int)(polyhedron.Faces[polygon].Color.B * I);
                            B = B > 0 && B < 255 ? B : B > 0 ? 255 : 0;
                            Color color = Color.FromArgb(R, G, B);
                            double z = 0;
                            z = (-(coef[0] * x + coef[2] * y + coef[3]) / coef[1]);

                            if (x > 0 && y > 0 && x < bmp.Width && y < bmp.Height)
                                if (z > ZBuffer[x, bmp.Height - y])
                                {
                                    ZBuffer[x, bmp.Height - y] = z;
                                    bmp.SetPixel(x, bmp.Height - y, color);
                                }
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private static int CalculateX(Point3D p1, Point3D p2, int y)
        {
            double k = (double)(p2.X - p1.X) / (p2.Z - p1.Z);
            int res = (int)(p1.X + (y - p1.Z) * k);
            return res;
        }

        private double GetCos(Vector v1, Vector v2)
        {
            return Vector.ScalarMultiplying(v1, v2) / (v1.Length * v2.Length);
        }

        private Polyhedron GetСylinder(int VertexesCount, int length, int height)
        {
            Point2D center = new Point2D(0, 0);

            List<Point3D> vertexes = new List<Point3D>();
            for (int i = 0; i < VertexesCount; i++)
            {
                Point2D p = new Point2D(center.X + length, center.Y);
                p = Grafic.Rotation(center, p, 2 * Math.PI * i / VertexesCount);
                vertexes.Add(new Point3D(p.X, p.Y, 0));
            }
            List<Polygon3D> polygons = new List<Polygon3D>();
            polygons.Add(new Polygon3D(vertexes.ToArray()) { Color = Color.Green });

            for (int i = 0; i < VertexesCount; i++)
            {
                Point2D p = new Point2D(center.X + length, center.Y);

                p = Grafic.Rotation(center, p, 2 * Math.PI * i / VertexesCount);
                vertexes.Add(new Point3D(p.X, p.Y, height));
            }

            polygons.Add(new Polygon3D(vertexes.GetRange(VertexesCount, VertexesCount).ToArray()) { Color = Color.Green });

            for (int i = 0; i < VertexesCount - 1; i++)
            {
                Polygon3D polygon = new Polygon3D(new Point3D[] { vertexes[i], vertexes[i + 1], vertexes[VertexesCount + i + 1], vertexes[VertexesCount + i] }) { Color = Color.Green };
                polygons.Add(polygon);
            }
            polygons.Add(new Polygon3D(new Point3D[] { vertexes[VertexesCount - 1], vertexes[0], vertexes[VertexesCount], vertexes[2 * VertexesCount - 1] }) { Color = Color.Green });

            return new Polyhedron(polygons.ToArray(), vertexes.ToArray());
        }

        private Polyhedron GetCone(int VertexesCount, int length, int height)
        {

            Point2D center = new Point2D(0, 0);


            List<Point3D> vertexes = new List<Point3D>();
            vertexes.Add(new Point3D(center.X, center.Y, height));
            for (int i = 0; i < VertexesCount; i++)
            {
                Point2D p = new Point2D(center.X + length, center.Y);

                p = Grafic.Rotation(center, p, 2 * Math.PI * i / VertexesCount);
                vertexes.Add(new Point3D(p.X, p.Y, 0));
            }
            List<Polygon3D> polygons = new List<Polygon3D>();
            polygons.Add(new Polygon3D(vertexes.GetRange(1, VertexesCount).ToArray()) { Color = Color.Green });

            for (int i = 1; i < VertexesCount; i++)
            {
                Polygon3D polygon = new Polygon3D(new Point3D[] { vertexes[0], vertexes[i], vertexes[i + 1] }) { Color = Color.Green };
                polygons.Add(polygon);
            }
            polygons.Add(new Polygon3D(new Point3D[] { vertexes[0], vertexes[VertexesCount], vertexes[1] }) { Color = Color.Green });

            return new Polyhedron(polygons.ToArray(), vertexes.ToArray());

        }
    }
}
