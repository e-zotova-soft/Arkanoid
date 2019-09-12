using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Arkanoid
{
    class SortByPoint: IComparer
    {
        int IComparer.Compare(object o1, object o2)
        {
            ClassResult m1 = (ClassResult)o1;
            ClassResult m2 = (ClassResult)o2;
            if (m1.ResPoint > m2.ResPoint) return 1;
            if (m1.ResPoint == m2.ResPoint) return 0;
            else return -1;
        }
    }
}
