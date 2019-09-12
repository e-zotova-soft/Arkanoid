using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Arkanoid
{
    class ClassBlockLifes: ClassBlock
    {
        private int LifeTime;
        // конструктор получает цветовой индекс блока - это определет количество жизней блока
        public ClassBlockLifes(System.Drawing.Size Size, System.Drawing.Point Location, int ColorIndex)
        {
            this.Size = Size;
            this.Location = Location;

            if (ColorIndex >=0 && ColorIndex <=4)
                this.ColorIndex = ColorIndex;
            else this.ColorIndex = 0;

            LifeTime = this.ColorIndex + 1;
            BackColor = BlockColor[ColorIndex];
        }
        
        public override bool Crossing()
        {
            if (--LifeTime <= 0)
            {
                return true;
            }
            else
            {
                BackColor = BlockColor[--ColorIndex];
                return false;
            }
        }

        //-------------
    }
}
