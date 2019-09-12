using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Arkanoid
{
    class ClassBlockSpeed : ClassBlock
    {
        // блок 1 жизни, замедляет движение шарика, красный
        public ClassBlockSpeed(Size Size, Point Location)
        {
            this.Size = Size;
            this.Location = Location;
            ColorIndex = 3;
            BackColor = BlockColor[ColorIndex];
        }

        public delegate void BallSpeedEventHandler();
        public event BallSpeedEventHandler BallSpeedLower;

       
        public override bool Crossing()
        {
            this.BallSpeedLower();
            return true;
        }

        //-----------------------
    }
}
