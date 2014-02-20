
/*
 *  MetaphysicsIndustries.Utilities
 *  Copyright (C) 2014 Metaphysics Industries, Inc., Richard Sartor
 *
 *  This program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License along
 *  with this program; if not, write to the Free Software Foundation, Inc.,
 *  51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * 
 */

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
            X = x;
            Y = y;
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

        public readonly float X;
        public readonly float Y;

        public override bool Equals(object obj)
        {
            if (obj is Vector)
            {
                Vector v = (Vector)obj;
                return X == v.X && Y == v.Y;
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
