using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    class Vector
    {
        private double x;
        private double y;
        private double z;
        public double X { get { return x; } set { x = value; GetLength(); } }
        public double Y { get { return y; } set { y = value; GetLength(); } }
        public double Z { get { return z; } set { z = value; GetLength(); } }
        public double Length { get; private set; }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Vector()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }
        private void GetLength()
        {
            Length = Math.Pow((Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2)), 0.5);
        }

        #region operators
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }
        public static Vector operator *(Vector v, double a)
        {
            return new Vector(v.X * a, v.Y * a, v.Z * a);
        }
        public static Vector operator /(Vector v, double a)
        {
            return new Vector(v.X / a, v.Y / a, v.Z / a);
        }
        #endregion

        public static double ScalarMultiplying(Vector v1, Vector v2)
        {
            return v1.X* v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }
    }
}
