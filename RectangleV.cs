
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
    [DebuggerDisplay("{X}, {Y}, {Width}, {Height}")]
    public struct RectangleV
    {
        public RectangleV(Rectangle rect)
        {
            _x=rect.X;
            _y = rect.Y;
            _width = rect.Width;
            _height = rect.Height;
        }

        public RectangleV(RectangleF rect)
        {
            _x=rect.X;
            _y = rect.Y;
            _width = rect.Width;
            _height = rect.Height;
        }

        public RectangleV(float x, float y, float width, float height)
        {
            _x=x;
            _y = y;
            _width = width;
            _height = height;
        }

        public RectangleV(Vector topLeft, Vector bottomRight)
        {
            _x=topLeft.X;
            _y = topLeft.Y;
            _width = bottomRight.X - topLeft.X;
            _height = bottomRight.Y - topLeft.Y;
        }

        public RectangleV(Vector location, SizeV size)
        {
            _x = location.X;
            _y = location.Y;
            _width = size.Width;
            _height = size.Height;
        }

        public static RectangleV FromLTRB(float left, float top, float right, float bottom)
        {
            return new RectangleV(new Vector(left, top), new Vector(right, bottom));
        }

        public static RectangleV FromCenterAndSize(Vector center, SizeV size)
        {
            Vector location = center - new Vector(size.Width, size.Height) / 2;

            return new RectangleV(location, size);
        }

        public static RectangleV BoundingBoxFromPoints(params Vector[] points)
        {
            if (points == null) { throw new ArgumentNullException("points"); }

            if (points.Length < 1)
            {
                return new RectangleV(0, 0, 0, 0);
            }

            float xmin = points[0].X;
            float xmax = points[0].X;
            float ymin = points[0].Y;
            float ymax = points[0].Y;

            foreach (Vector v in points)
            {
                xmin = Math.Min(xmin, v.X);
                xmax = Math.Max(xmax, v.X);
                ymin = Math.Min(ymin, v.Y);
                ymax = Math.Max(ymax, v.Y);
            }

            return RectangleV.FromLTRB(xmin, ymin, xmax, ymax);
        }

        private float _x;
        public float X
        {
            get { return _x; }
        }

        private float _y;
        public float Y
        {
            get { return _y; }
        }

        private float _width;
        public float Width
        {
            get { return _width; }
        }

        private float _height;
        public float Height
        {
            get { return _height; }
        }

        public float Left
        {
            get { return _x; }
        }
        public float Top
        {
            get { return _y; }
        }
        public float Right
        {
            get { return _x+_width; }
        }
        public float Bottom
        {
            get { return _y + _height; }
        }

        public Vector TopLeft
        {
            get { return new Vector(Left, Top); }
        }
        public Vector TopRight
        {
            get { return new Vector(Right, Top); }
        }
        public Vector BottomLeft
        {
            get { return new Vector(Left, Bottom); }
        }
        public Vector BottomRight
        {
            get { return new Vector(Right, Bottom); }
        }

        public Vector LeftCenter
        {
            get { return new Vector(Left, (Top + Bottom) / 2); }
        }
        public Vector TopCenter
        {
            get { return new Vector((Left + Right) / 2, Top); }
        }
        public Vector RightCenter
        {
            get { return new Vector(Right, (Top + Bottom) / 2); }
        }
        public Vector BottomCenter
        {
            get { return new Vector((Left + Right) / 2, Bottom); }
        }

        public Vector Location
        {
            get { return TopLeft; }
        }
        public SizeV Size
        {
            get { return new SizeV(Width, Height); }
        }

        public Vector CalcCenter()
        {
            return new Vector(Left + Width / 2, Top + Height / 2);
        }

        //op implicit
        public static implicit operator RectangleF(RectangleV rect)
        {
            return new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
        }
        public static implicit operator RectangleV(RectangleF rect)
        {
            return new RectangleV(rect.X, rect.Y, rect.Width, rect.Height);
        }


        public override bool Equals(object obj)
        {
            if (obj is RectangleV)
            {
                RectangleV rect = (RectangleV)obj;
                return 
                    this.X == rect.X && 
                    this.Y == rect.Y && 
                    this.Width == rect.Width && 
                    this.Height == rect.Height;
            }

            return base.Equals(obj);
        }

        public static bool operator ==(RectangleV a, RectangleV b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(RectangleV a, RectangleV b)
        {
            return !(a == b);
        }
        public override int GetHashCode()
        {
            return
                X.GetHashCode() ^
                Y.GetHashCode() ^
                Width.GetHashCode() ^
                Height.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("{{X={0}, Y={1}, Width={2}, Height={3}}}", X, Y, Width, Height);
        }

        //+SizeV
        //-SizeV

        public RectangleV Union(RectangleV rect)
        {
            return RectangleV.UnionAll(this, rect);
        }
        public static RectangleV UnionAll(params RectangleV[] rects)
        {
            if (rects==null || rects.Length<1) { return new RectangleV();}

            float left=rects[0].Left;
            float top=rects[0].Top;
            float right=rects[0].Right;
            float bottom=rects[0].Bottom;

            foreach (RectangleV rect in rects)
            {
                left = Math.Min(left, rect.Left);
                top = Math.Min(top, rect.Top);
                right = Math.Max(right, rect.Right);
                bottom = Math.Max(bottom, rect.Bottom);
            }

            return new RectangleV(left, top, right - left, bottom - top);
        }
        public RectangleV Intersect(RectangleV rect)
        {
            return IntersectAll(this, rect);
        }
        private RectangleV IntersectAll(params RectangleV[] rects)
        {
            if (rects == null || rects.Length < 1) { return new RectangleV(); }

            float left = rects[0].Left;
            float top = rects[0].Top;
            float right = rects[0].Right;
            float bottom = rects[0].Bottom;

            foreach (RectangleV rect in rects)
            {
                left = Math.Max(left, rect.Left);
                top = Math.Max(top, rect.Top);
                right = Math.Min(right, rect.Right);
                bottom = Math.Min(bottom, rect.Bottom);
            }

            return new RectangleV(left, top, right - left, bottom - top);
        }

        public RectangleV Inflate(SizeV size)
        {
            return RectangleV.FromLTRB(
                Left - size.Width, 
                Top - size.Height, 
                Right + size.Width, 
                Bottom + size.Height);
        }
        public RectangleV Inflate(float x, float y)
        {
            return Inflate(new SizeV(x, y));
        }

        public RectangleV Offset(Vector v)
        {
            return new RectangleV(TopLeft + v, Size);
        }
        public RectangleV Offset(float x, float y)
        {
            return Offset(new Vector(x, y));
        }

        public bool IntersectsWith(RectangleV rect)
        {
            return IntersectsWith(rect, true);
        }
        public bool IntersectsWith(RectangleV rect, bool inclusive)
        {
            if (inclusive)
            {
                if (Left <= rect.Right &&
                    Right >= rect.Left &&
                    Top <= rect.Bottom &&
                    Bottom >= rect.Top)
                {
                    return true;
                }
            }
            else
            {
                if (Left < rect.Right &&
                    Right > rect.Left &&
                    Top < rect.Bottom &&
                    Bottom > rect.Top)
                {
                    return true;
                }
            }

            return false;
        }
        public bool Contains(Vector v)
        {
            if (Left <= v.X &&
                Right >= v.X &&
                Top <= v.Y &&
                Bottom >= v.Y)
            {
                return true;
            }

            return false;
        }

        public bool IsEmpty
        {
            get { return (Width == 0 || Height == 0); }
        }


        //truncate
        //round
        //floor
        //ceiling
    }
}
