using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Arkanoid
{
    abstract class ClassBlock
    {
        protected Size Size;
        protected Point Location;
        protected Color[] BlockColor = {Color.DodgerBlue, Color.Yellow, Color.GreenYellow, Color.Tomato, Color.MediumPurple};
        protected int ColorIndex;
        protected Color BackColor;
        
        // отрисовка блока
        public void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(BackColor), Location.X, Location.Y, Size.Width, Size.Height);
            g.DrawRectangle(new Pen(Color.Black), Location.X, Location.Y, Size.Width, Size.Height);
        }

        // размер блока
        public Rectangle Bounds
        {
            get
            {
                Rectangle Rect = new Rectangle(Location.X, Location.Y, Size.Width, Size.Height);
                return Rect;
            }
        }

        // реакция на пересечение с мячом (исчезание или уменьшение жизни блока, или появление бонуса)
        // разная для различных классов блока
        public abstract bool Crossing();
        
        //--------------------
    }
}
