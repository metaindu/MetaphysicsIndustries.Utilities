using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace MetaphysicsIndustries.Utilities
{
    [DebuggerDisplay("{Width}, {Height}")]
    public struct SizeV
    {
        public SizeV(float width, float height)
        {
            _width = width;
            _height = height;
        }

        public SizeV(Size size)
        {
            _width = size.Width;
            _height = size.Height;
        }

        public SizeV(SizeF size)
        {
            _width = size.Width;
            _height = size.Height;
        }

        public SizeV(Vector v)
        {
            _width = v.X;
            _height = v.Y;
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

        //op implicit
        public static implicit operator SizeF(SizeV v)
        {
            return new SizeF(v.Width, v.Height);
        }
        public static implicit operator SizeV(SizeF pt)
        {
            return new SizeV(pt.Width, pt.Height);
        }

        public override bool Equals(object obj)
        {
            if (obj is SizeV)
            {
                SizeV v = (SizeV)obj;
                return this.Width == v.Width && this.Height == v.Height;
            }

            return base.Equals(obj);
        }
        public static bool operator ==(SizeV a, SizeV b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(SizeV a, SizeV b)
        {
            return !(a == b);
        }
        public override int GetHashCode()
        {
            return Width.GetHashCode() ^ Height.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("{{Width={0}, Height={1}}}", Width, Height);
        }

    }
}
