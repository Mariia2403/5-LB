using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    internal class Circle:Figure
    {
       
        private int radius;
        //  private int size;

        public Circle(int centerX, int centerY, int radius, Form form) : base(form)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            this.radius = radius;
        }

        public override void Draw(Graphics graphics)
        {
            using (Brush brush = new SolidBrush(color))
            {
                graphics.FillEllipse(brush, centerX - radius, centerY - radius, radius * 2, radius * 2);
            }

            graphics.DrawEllipse(Pens.Black, centerX - radius, centerY - radius, radius * 2, radius * 2);
        }
        public override int GetRightBoundary()
        {
            return centerX + radius;
        }

        public override int GetLeftBoundary()
        {
            return centerX - radius;
        }

        public override int GetTopBoundary()
        {
            return centerY - radius;
        }

        public override int GetBottomBoundary()
        {
            return centerY + radius;
        }
    }
}
