using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
       
        private Figure currentFigure;
        private System.Windows.Forms.Timer animationTimer;
        private int direction = 1;
        private int deltaX = 0; // Напрямок руху по X
        private int deltaY = 0; // Напрямок руху по Y
        private Random random;
        public Form1()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();

            InitializeComponent();
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 10; 
            animationTimer.Tick += AnimationTimer_Tick;

            random = new Random();

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (currentFigure != null)
            {
                currentFigure.Draw(e.Graphics);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            ToggleFigureMovement(new Square(100, 200, 50,this));
          //  currentFigure.MoveRight(this);
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ToggleFigureMovement(new Circle(200, 200, 50,this));
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
          
            ToggleFigureMovement(new Rhomb(200, 200, 120, 80, this));
        }

       
        private void ToggleFigureMovement(Figure newFigure)
        {
            if (currentFigure != null && currentFigure.GetType() == newFigure.GetType())
            {
                StopAnimation();
                currentFigure = null;
            }
            else
            {
                StopAnimation(); // Зупиняємо поточну анімацію, якщо вона є

                currentFigure = newFigure;
                StartAnimation();
            }
        }
        private void StartAnimation()
        {
            if (currentFigure != null)
            {
                deltaX = 5; // Початковий рух вправо
                deltaY = 0; // Без вертикального руху
                animationTimer.Start(); // Починаємо таймер для анімації
            }
        }

        private void StopAnimation()
        {
            animationTimer.Stop(); // Зупиняємо таймер
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (currentFigure != null)
            {
                // Рух фігури у напрямку deltaX та deltaY
                currentFigure.Move(deltaX, deltaY);

                // Перевірка досягнення меж форми для запобігання виходу фігури за межі
                if (currentFigure.GetRightBoundary() >= this.ClientSize.Width)
                {
                    // Якщо права межа досягла або перевищила ширину форми, змінюємо напрямок на вліво
                    deltaX = -Math.Abs(deltaX);
                }

                if (currentFigure.GetLeftBoundary() <= 0)
                {
                    // Якщо ліва межа досягла або перевищила 0, змінюємо напрямок на вправо
                    deltaX = Math.Abs(deltaX);
                }

                if (currentFigure.GetBottomBoundary() >= this.ClientSize.Height)
                {
                    // Якщо нижня межа досягла або перевищила висоту форми, змінюємо напрямок на вгору
                    deltaY = -Math.Abs(deltaY);
                }

                if (currentFigure.GetTopBoundary() <= 0)
                {
                    // Якщо верхня межа досягла або перевищила 0, змінюємо напрямок на вниз
                    deltaY = Math.Abs(deltaY);
                }

                Invalidate(); // Оновлюємо форму для перерисовки
            }
        }

            private void button3_Click(object sender, EventArgs e)
        {

            if (currentFigure != null)
            {
                // Генеруємо випадковий колір
                Color newColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                currentFigure.Color = newColor;

                Invalidate(); // Оновлюємо форму для перерисовки
            }
            else
            {
                // Фігура ще не створена - показуємо повідомлення користувачу
                MessageBox.Show("Будь ласка, спочатку оберіть фігуру для зміни кольору!", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentFigure != null)
            {
                // Генеруємо випадкові напрямки для X та Y
                deltaX = random.Next(-5, 6); // Рух вліво або вправо (-5 до +5)
                deltaY = random.Next(-5, 6); // Рух вгору або вниз (-5 до +5)

                // Починаємо анімацію, якщо вона ще не запущена
                if (!animationTimer.Enabled)
                {
                    animationTimer.Start();
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, спочатку оберіть фігуру для руху!", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
