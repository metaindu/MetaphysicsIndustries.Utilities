using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Drawing;

namespace MetaphysicsIndustries.Utilities
{
    [DebuggerDisplay("{X}, {Y}, Length = {Length}")]
    public struct Vector
    {
        public Vector(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public static Vector FromPolar(float theta, float length)
        {
            return length * new Vector((float)Math.Cos(theta), (float)Math.Sin(theta));
        }

        public static Vector OffsetX(float x)
        {
            return new Vector(x, 0);
        }
        public static Vector OffsetY(float y)
        {
            return new Vector(0, y);
        }

        public float Length
        {
            get { return (float)Math.Sqrt(LengthSquared); }
        }

        public float LengthSquared
        {
            get { return DotProduct(this, this); }
        }

        public float CalcTheta()
        {
            return (float)Math.Atan2(Y, X);
        }

        public static readonly Vector Zero = new Vector(0, 0);

        public static float DotProduct(Vector v, Vector u)
        {
            return u.X * v.X + u.Y * v.Y;
        }
        public static float CrossProduct(Vector a, Vector b)
        {
            return a.X * b.Y - a.Y * b.X;
        }

        public static Vector operator -(Vector v)
        {
            return new Vector(-v.X, -v.Y);
        }
        public static Vector operator *(float scale, Vector v)
        {
            return v * scale;
        }
        public static Vector operator *(Vector v, float scale)
        {
            return new Vector(scale * v.X, scale * v.Y);
        }
        public static Vector operator +(Vector v, Vector u)
        {
            return new Vector(u.X + v.X, u.Y + v.Y);
        }
        public static Vector operator -(Vector v, Vector u)
        {
            return new Vector(v.X - u.X, v.Y - u.Y);
        }
        public static Vector operator /(Vector v, float scale)
        {
            return new Vector(v.X / scale, v.Y / scale);
        }
        //public Vector operator *(Vector rect, float scale)
        //{
        //    return new Vector(scale * rect.X, scale * rect.Y);
        //}

        public static implicit operator PointF(Vector v)
        {
            return new PointF(v.X, v.Y);
        }
        public static implicit operator Vector(PointF pt)
        {
            return new Vector(pt.X, pt.Y);
        }
        public Vector Normalized()
        {
            return this / Length;
        }

        private float _x;
        private float _y;
        public float X
        {
            get { return _x; }

            //i'm sure that there's a perfectly good reason for 
            //this accessor being private, but i don't know what
            //it is 
            //private set { _x = value; } 
        }
        public float Y
        {
            get { return _y; }

            //i'm sure that there's a perfectly good reason for 
            //this accessor being private, but i don't know what
            //it is 
            private set { _y = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector)
            {
                Vector v = (Vector)obj;
                return this.X == v.X && this.Y == v.Y;
            }

            return base.Equals(obj);
        }

        public static bool operator ==(Vector a, Vector b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Vector a, Vector b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("{{X={0}, Y={1}}}", X, Y);
        }

        public static PointF[] ConvertArray(Vector[] array)
        {
            return Array.ConvertAll<Vector, PointF>(array, PointFFromVector);
        }
        public static PointF PointFFromVector(Vector v)
        {
            return v;
        }
        public static Vector[] ConvertArray(PointF[] array)
        {
            return Array.ConvertAll<PointF, Vector>(array, VectorFromPointF);
        }
        public static Vector VectorFromPointF(PointF pt)
        {
            return pt;
        }
    }
}
