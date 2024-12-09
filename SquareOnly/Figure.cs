using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
   abstract class Figure
    {
        protected int centerX;
        protected int centerY;
        protected Color color; // Колір фігури за замовчуванням

        public abstract int GetRightBoundary();
        public abstract int GetLeftBoundary();
        public virtual int GetTopBoundary() => centerY - 10;
        public virtual int GetBottomBoundary() => centerY + 10;
        public abstract void Draw(Graphics graphics);

        public Figure(Form form)
        {
            // Встановлюємо початковий колір фігури таким самим, як колір фону форми
            this.color = form.BackColor;
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

       /* public virtual void MoveRight(Form form)
        {
            centerX += 1; // Переміщуємо вправо на 5 одиниць (можна змінити для інших швидкостей)
        }
        public virtual void Move(int direction)
        {
            centerX += 5 * direction; // Змінюємо позицію по X залежно від напрямку
        }*/

        public virtual void Move(int deltaX, int deltaY)
        {
            centerX += deltaX;
            centerY += deltaY;
        }
      

    }
}
