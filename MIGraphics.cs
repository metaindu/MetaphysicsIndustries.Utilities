using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MetaphysicsIndustries.Utilities
{
    public class MIGraphics
    {
        public static void DrawRoundedRectangle(Graphics g, Pen pen, float cornerRadius, RectangleV rect)
        {
            DrawRoundedRectangle(g, pen, cornerRadius, rect.X, rect.Y, rect.Width, rect.Height);
        }
        public static void DrawRoundedRectangle(Graphics g, Pen pen, float cornerRadius, float x, float y, float width, float height)
        {
            if (cornerRadius > width / 2)
            {
                DrawRoundedRectangle(g, pen, width / 2, x, y, width, height);
            }
            else if (cornerRadius > height / 2)
            {
                DrawRoundedRectangle(g, pen, height / 2, x, y, width, height);
            }
            else
            {
                float r = x + width;
                float b = y + height;
                float cr2 = cornerRadius * 2;

                g.DrawArc(pen, x, y, cr2, cr2, -180, 90);
                g.DrawArc(pen, r - cr2, y, cr2, cr2, -90, 90);
                g.DrawArc(pen, r - cr2, b - cr2, cr2, cr2, 0, 90);
                g.DrawArc(pen, x, b - cr2, cr2, cr2, 90, 90);

                g.DrawLine(pen, x + cornerRadius, y, r - cornerRadius, y);
                g.DrawLine(pen, x, y + cornerRadius, x, b - cornerRadius);
                g.DrawLine(pen, x + cornerRadius, b, r - cornerRadius, b);
                g.DrawLine(pen, r, y + cornerRadius, r, b - cornerRadius);
            }
        }

        public static void DrawRoundedRectanglePartialLeft(Graphics g, Pen pen, float cornerRadius, float x, float y, float width, float height)
        {
            if (cornerRadius > width / 2)
            {
                DrawRoundedRectanglePartialLeft(g, pen, width / 2, x, y, width, height);
            }
            if (cornerRadius > height / 2)
            {
                DrawRoundedRectanglePartialLeft(g, pen, height / 2, x, y, width, height);
            }

            float r = x + width;
            float b = y + height;
            float cr2 = cornerRadius * 2;

            g.DrawArc(pen, x, y, cr2, cr2, -180, 90);
            g.DrawArc(pen, x, b - cr2, cr2, cr2, 90, 90);

            g.DrawLine(pen, x + cornerRadius, y, r, y);
            g.DrawLine(pen, x, y + cornerRadius, x, b - cornerRadius);
            g.DrawLine(pen, x + cornerRadius, b, r, b);
        }

        public static void DrawRoundedRectanglePartialRight(Graphics g, Pen pen, float cornerRadius, float x, float y, float width, float height)
        {
            if (cornerRadius > width / 2)
            {
                DrawRoundedRectanglePartialRight(g, pen, width / 2, x, y, width, height);
            }
            if (cornerRadius > height / 2)
            {
                DrawRoundedRectanglePartialRight(g, pen, height / 2, x, y, width, height);
            }

            float r = x + width;
            float b = y + height;
            float cr2 = cornerRadius * 2;

            g.DrawArc(pen, r - cr2, y, cr2, cr2, -90, 90);
            g.DrawArc(pen, r - cr2, b - cr2, cr2, cr2, 0, 90);

            g.DrawLine(pen, x , y, r - cornerRadius, y);
            g.DrawLine(pen, x , b, r - cornerRadius, b);
            g.DrawLine(pen, r, y + cornerRadius, r, b - cornerRadius);
        }


        public static void DrawRoundedRectanglePartialTop(Graphics g, Pen pen, float cornerRadius, float x, float y, float width, float height)
        {
            if (cornerRadius > width / 2)
            {
                DrawRoundedRectanglePartialTop(g, pen, width / 2, x, y, width, height);
            }
            if (cornerRadius > height / 2)
            {
                DrawRoundedRectanglePartialTop(g, pen, height / 2, x, y, width, height);
            }

            float r = x + width;
            float b = y + height;
            float cr2 = cornerRadius * 2;

            g.DrawArc(pen, x, y, cr2, cr2, -180, 90);
            g.DrawArc(pen, r - cr2, y, cr2, cr2, -90, 90);

            g.DrawLine(pen, x + cornerRadius, y, r - cornerRadius, y);
            g.DrawLine(pen, x, y + cornerRadius, x, b);
            g.DrawLine(pen, r, y + cornerRadius, r, b);
        }

        public static void DrawRoundedRectanglePartialBottom(Graphics g, Pen pen, float cornerRadius, float x, float y, float width, float height)
        {
            if (cornerRadius > width / 2)
            {
                DrawRoundedRectanglePartialBottom(g, pen, width / 2, x, y, width, height);
            }
            if (cornerRadius > height / 2)
            {
                DrawRoundedRectanglePartialBottom(g, pen, height / 2, x, y, width, height);
            }

            float r = x + width;
            float b = y + height;
            float cr2 = cornerRadius * 2;

            g.DrawArc(pen, r - cr2, b - cr2, cr2, cr2, 0, 90);
            g.DrawArc(pen, x, b - cr2, cr2, cr2, 90, 90);

            g.DrawLine(pen, x, y, x, b - cornerRadius);
            g.DrawLine(pen, x + cornerRadius, b, r - cornerRadius, b);
            g.DrawLine(pen, r, y, r, b - cornerRadius);
        }


        public static void FillRoundedRectangle(Graphics g, Brush brush, float cornerRadius, RectangleV rect)
        {
            FillRoundedRectangle(g, brush, cornerRadius, rect.X, rect.Y, rect.Width, rect.Height);
        }
        public static void FillRoundedRectangle(Graphics g, Brush brush, float cornerRadius, float x, float y, float width, float height)
        {
            if (cornerRadius > width / 2)
            {
                FillRoundedRectangle(g, brush, width / 2, x, y, width, height);
            }
            else if (cornerRadius > height / 2)
            {
                FillRoundedRectangle(g, brush, height / 2, x, y, width, height);
            }
            else
            {
                float r = x + width;
                float b = y + height;
                float cr2 = cornerRadius * 2;

                g.FillEllipse(brush, x, y, cr2, cr2);
                g.FillEllipse(brush, x + width - cr2, y, cr2, cr2);
                g.FillEllipse(brush, x + width - cr2, y + height - cr2, cr2, cr2);
                g.FillEllipse(brush, x, y + height - cr2, cr2, cr2);

                g.FillRectangle(brush, x + cornerRadius, y, width - 2*cornerRadius, height);
                g.FillRectangle(brush, x, y + cornerRadius, width, height - 2*cornerRadius);
            }
        }
    }
}
