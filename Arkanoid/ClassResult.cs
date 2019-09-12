using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;

namespace Arkanoid
{
    class ClassResult
    {
        private int Point;
        private string Name;
        public ClassResult(string Name, int Point)
        {
            this.Name = Name;
            this.Point = Point;
        }
        public int ResPoint
        {
            get
            {
                return Point;
            }
        }

        public string ResName
        {
            get
            {
                return Name;
            }
        }

        public static IComparer SortByPoint
        {
            get
            {
                return (IComparer)new SortByPoint();
            }
        }
        //----------
    }
}
