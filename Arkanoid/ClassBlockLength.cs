using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Arkanoid
{
    class ClassBlockLength: ClassBlock
    {
        public ClassBlockLength(Size Size, Point Location)
        {
            this.Size = Size;
            this.Location = Location;
            ColorIndex = 4;
            BackColor = BlockColor[ColorIndex];
        }

        public delegate void RacketEventHandler();
        public event RacketEventHandler RacketLength;

       
        public override bool Crossing()
        {
            this.RacketLength();
            return true;
        }
    }
}
