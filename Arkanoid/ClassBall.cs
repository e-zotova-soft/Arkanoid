using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Arkanoid
{
    // МЯЧ
    class ClassBall
    {
        // скорость движение мячика вдоль осей координат
        private int SpeedX;
        private int SpeedY;
        private Timer LowerTimer = new Timer();
        private Rectangle RectField;
        private PictureBox Pbox = new PictureBox();//(для графического отображения мячика)

        public delegate void BallLost_event();
        
        // событие потери мячика
        public event BallLost_event BallLost;
    
        public ClassBall(Panel panelToAdd)
        {
            // по умолчанию
            BallParams(panelToAdd.ClientRectangle);
            InitBall();
            panelToAdd.Controls.Add(Pbox);
        }

        // снижение скорости мячика
        private void LowerSpeed()
        {
            if (SpeedX == 2) SpeedX--;
            else
                if (SpeedX == -2) SpeedX++;
            if (SpeedY == 2) SpeedY = SpeedY--;
            else
                if (SpeedY == -2) SpeedY = SpeedY++;
        }

        public void Lower()
        {
            LowerSpeed();
            LowerTimer.Interval = ClassConstants.TimerInterval;
            LowerTimer.Tick += new EventHandler(LowerTimer_Tick);
            LowerTimer.Start();
        }

        // увеличение скорости мячика
        private void RaiseSpeed()
        {
            if (SpeedX == 1) SpeedX++;
            else
                if (SpeedX == -1) SpeedX--;
            if (SpeedY == 1) SpeedY = SpeedY++;
            else
                if (SpeedY == -1) SpeedY = SpeedY--;
        }

        // окончание периода движения мячика с маленькой скоростью
        void LowerTimer_Tick(object sender, EventArgs e)
        {
            RaiseSpeed();
            LowerTimer.Stop();
        }

// задание конкретных параметров появления мячика на форме
        public void BallParams(Rectangle Rect)
        {
            // место появление мячика на форме: параметры по умолчанию
            Pbox.Location = new Point(Rect.Width / 2, Rect.Height * 2 / 3);
            RectField = Rect;
            SpeedX = 2;
            SpeedY = -SpeedX;
            
        }

// загружается рисунок мячика
        private void InitBall()
        {
            Image img = Image.FromFile("ball.gif");
            Pbox.Image = img;
            Pbox.Width = img.Width;
            Pbox.Height = img.Height;
        }

// методы изменения направления движения мячика
        public void ReverseX()
        {
            SpeedX *= -1;
        }

        public void ReverceY()
        {
            SpeedY *= -1;
        }

        public int BallSpeedX
        {
            get
            {
                return SpeedX;
            }
            set
            {
                if (value >= -2 && value <= 2)
                    SpeedX = value;
            }
        }

        public int BallSpeedY
        {
            get
            {
                return SpeedY;
            }
            set
            {
                if (value >= -2 && value <= 2)
                    SpeedY = value;
            }
        }

// подсчет нового положения мячика
        public Rectangle CountNextLocation()
        {
            // надо сдвинуть на значение скорости перемещения мячика 
            Rectangle Next = new Rectangle(Pbox.Location.X + SpeedX, Pbox.Location.Y + SpeedY, Pbox.Width, Pbox.Height);
            // продолжаем расчет нового прямоугольника, занимаемого мячом
            // проверка, если мяч выходит за пределы поля - отразить направление движения
            // если мяч выходит за боковую стенку
            if (Next.Right >= RectField.Right || Next.Left <= RectField.Left)
            {
                ReverseX();
                // вернуть предыдущие значение X положения мячика 
                Next.X = Pbox.Location.X;
            }
            // если мяч выходит за верхний предел
            if (Next.Top <= 0)
            {
                ReverceY();
                Next.Y = Pbox.Location.Y;
            }
            // нижний предел
            if (Next.Bottom >= RectField.Bottom)
            {
                //ReverceY();
                BallLost(); // событие: мячик упал
                return Next;
            }
            Pbox.Location = new Point(Next.X, Next.Y);
            return Next;
        }

        //--------------------
    }
}
