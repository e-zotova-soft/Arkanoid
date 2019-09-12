using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Arkanoid
{
    // РАКЕТКА (пока только двигается, мячик еще не ловит)
    class ClassRacket
    {
        private int Speed; // скорость движения ракетки
        private bool ToRight;// направление движения ракетки
        private bool Stopped;
        private Rectangle RectField;
        private PictureBox Pbox = new PictureBox();//(для графического отображения hfrtnrb)
        private Timer TimerLarge = new Timer();

        public ClassRacket(Panel panelToAdd)
        {
            InitRacket("racket.gif");
            RectField = panelToAdd.ClientRectangle;
            RacketParams(RectField);
            panelToAdd.Controls.Add(this.Pbox);
        }

        public void RacketParams(Rectangle Rect)
        {
            // место появление ракетки на форме: параметры по умолчанию
            Pbox.Location = new Point(Rect.Width / 2, Rect.Height - Pbox.Height - 2);
            Speed = 3;
        }

        public void Large()
        {
            InitRacket("racket1.gif");
            TimerLarge.Interval = ClassConstants.TimerInterval;
            TimerLarge.Tick += new EventHandler(TimerLarge_Tick); 
            TimerLarge.Start();
        }

        void TimerLarge_Tick(object sender, EventArgs e)
        {
            TimerLarge.Stop();
            InitRacket("racket.gif");
        }

// загружается рисунок ракетки
        private void InitRacket(string filename)
        {
            Image img = Image.FromFile(filename);
            Pbox.Image = img;
            Pbox.Width = img.Width;
            Pbox.Height = img.Height;
        }

        public void RacketToRight()
        {
            ToRight = true;
            Stopped = false;
        }


        public void RacketToLeft()
        {
            ToRight = false;
            Stopped = false;
        }

        public void RacketStop()
        {
            Stopped = true;
        }

        public bool RacketIsStoped
        {
            get
            {
                return Stopped;
            }
        }

        public bool RacketIsToRight
        {
            get
            {
                return ToRight;
            }
        }

        public Rectangle Bounds
        {
            get
            {
                return Pbox.Bounds;
            }
        }

        public Rectangle CountNextLocation()
        {
            if (Stopped)
                return this.Bounds;
            int Step = 0;
            {
                if (ToRight)
                    Step = Pbox.Location.X + Speed;
                else
                    Step = Pbox.Location.X - Speed;
            }
            if ((!ToRight && Step > 0) || (ToRight && (Step + Pbox.Width) < RectField.Width))
            {
                Pbox.Location = new Point(Step, Pbox.Location.Y);
            }
            else
            {
                return this.Bounds;
            }
            return new Rectangle(Pbox.Location.X, Pbox.Location.Y, Pbox.Width, Pbox.Height);
        }

     
    }
}
