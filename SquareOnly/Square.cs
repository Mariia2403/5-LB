using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Square:Figure
    {
      //  private static Form form;
        private int size;

        public Square(int centerX, int centerY, int size, Form form) : base(form)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            this.size = size;
        }
        public override void Draw(Graphics graphics)
        {
            Point[] points = {
                new Point(centerX - size, centerY - size),
                new Point(centerX - size, centerY + size),
                new Point(centerX + size, centerY + size),
                new Point(centerX + size, centerY - size)
            };

            using (Brush brush = new SolidBrush(color))
            {
                graphics.FillPolygon(brush, points); // Заливаємо фігуру кольором
            }

            graphics.DrawPolygon(Pens.Black, points);
        }
        public override int GetRightBoundary()
        {
            return centerX + size;
        }

        public override int GetLeftBoundary()
        {
            return centerX - size;
        }

        public override int GetTopBoundary()
        {
            return centerY - size;
        }

        public override int GetBottomBoundary()
        {
            return centerY + size ;
        }
    }
}
