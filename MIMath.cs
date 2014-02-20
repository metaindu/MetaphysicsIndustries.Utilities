using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MetaphysicsIndustries.Utilities
{
    public static class MIMath
    {
        public static RectangleV CalcCircle(Vector A, Vector B, Vector C)
        {
            Vector ab = A - B;
            Vector bc = B - C;
            Vector ac = A - C;


            float a = bc.Length;
            float b = ac.Length;
            float c = ab.Length;

            float s = 0;

            PointF center = new PointF();

            //if (a == b ||
            //    b == c ||
            //    a == c)
            //{
            //    //degenerate case
            //    //only two points
            //    float maxx = Math.Max(A.X, Math.Max(B.X, C.X));
            //    float minx = Math.Min(A.X, Math.Min(B.X, C.X));
            //    float maxy = Math.Max(A.Y, Math.Max(B.Y, C.Y));
            //    float miny = Math.Min(A.Y, Math.Min(B.Y, C.Y));

            //    return new RectangleF(minx, miny, maxx - minx, maxy - miny);
            //}

            //if (a + b == c ||
            //    a + c == b ||
            //    b + c == a)
            if (Math.Abs(a + b - c) < 0.0001 ||
                Math.Abs(a + c - b) < 0.0001 ||
                Math.Abs(b + c - a) < 0.0001)
            {
                //degenerate case
                //colinear points

                return new RectangleV(A.X, A.Y, 0, 0);
            }

            s = Vector.CrossProduct(ab, bc);
            s *= 2 * s;

            float alpha = bc.LengthSquared * Vector.DotProduct(ab, ac) / s;
            float beta = ac.LengthSquared  * -Vector.DotProduct(ab, bc) / s;
            float gamma = ab.LengthSquared  * Vector.DotProduct(ac, bc) / s;

            center =
                new Vector(
                    alpha * A.X + beta * B.X + gamma * C.X,
                    alpha * A.Y + beta * B.Y + gamma * C.Y);

            float size = (center - A).Length * 2;

            return RectangleV.FromCenterAndSize(center, new SizeV(size, size));
        }

        public static float CalcAngle(Vector p, Vector a, Vector b)
        {
            return (float)System.Math.Acos(CalcCosAngle(p, a, b));
        }

        public static float CalcCosAngle(Vector p, Vector a, Vector b)
        {
            Vector ap = a - p;
            Vector bp = b - p;
            return (ap.X * bp.X - ap.Y * bp.Y) /
                (ap.Length * ap.Length);
        }

        public static float CalcArea(Vector a, Vector b, Vector c)
        {
            return (float)System.Math.Abs(a.X * c.Y - a.X * b.Y + b.X * a.Y - b.X * c.Y + c.X * b.Y - c.X * a.Y) / 2;
        }

        public static Vector CalcLineIntersection(Vector pt1a, Vector pt1b, Vector pt2a, Vector pt2b)
        {
            throw new NotImplementedException();
        }

        public static RectangleV CalcSmallestCircle(Vector a, Vector b)
        {
            Vector center = (a + b) / 2;
            float size = (a - b).Length;
            return RectangleV.FromCenterAndSize(center, new SizeV(size, size));
        }

        public static double Square(double x)
        {
            return x * x;
        }
        public static float Square(float x)
        {
            return x * x;
        }

        public static int Clamp(int value, int min, int max)
        {
            return Math.Max(Math.Min(value, max), min);
        }
        public static float Clamp(float value, float min, float max)
        {
            return Math.Max(Math.Min(value, max), min);
        }
        public static double Clamp(double value, double min, double max)
        {
            return Math.Max(Math.Min(value, max), min);
        }

        public static Vector CalcBezierPoint(Vector start, Vector controlPoint1, Vector controlPoint2, Vector end, float s)
        {
            float t = 1 - s;
            float a = t * t * t;
            float b = t * t * s * 3;
            float c = t * s * s * 3;
            float d = s * s * s;

            return a * start + b * controlPoint1 + c * controlPoint2 + d * end;
        }
    }
}
