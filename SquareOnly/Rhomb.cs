using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    internal class Rhomb:Figure
    {
       
        private int diagonal1;
        private int diagonal2;

        public Rhomb(int centerX, int centerY, int diagonal1, int diagonal2, Form form) : base(form)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            this.diagonal1 = diagonal1;
            this.diagonal2 = diagonal2;
        }

        public override void Draw(Graphics graphics)
        {
            Point[] points = {
                new Point(centerX, centerY - diagonal1 / 2),
                new Point(centerX - diagonal2 / 2, centerY),
                new Point(centerX, centerY + diagonal1 / 2),
                new Point(centerX + diagonal2 / 2, centerY)
            };
            using (Brush brush = new SolidBrush(color))
            {
                graphics.FillPolygon(brush, points); // Заливаємо фігуру кольором
            }

            graphics.DrawPolygon(Pens.Black, points);
        }

        public override int GetLeftBoundary()
        {
            return centerX - diagonal2 / 2;
        }

        public override int GetRightBoundary()
        {
            return centerX + diagonal2 / 2;
        }
    }
}

