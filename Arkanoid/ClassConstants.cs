using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arkanoid
{
    class ClassConstants
    {
        // параметры уровня: количество рядов блоков
        public static int countStrings = 4;
        // количество блоков в ряду
        public static int countBlocks = 8;
        // количество различных видов блоков
        public static int Count_Block_Types = 6;
        // количество мячей в начале игры
        public static int Count_Balls = 3;
        // количество очков в начале игры                
        public static int Count_Points = 0;
        // начальный уровень
        public static int Level = 0;
        // время действия реакции на блоки(замедление шарика, увеличение ракетки)
        public static int TimerInterval = 7000;
    }
}
