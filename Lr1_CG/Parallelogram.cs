using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr1_CG
{
    public class Parallelogram
    {
        public int x1;
        public int y1;

        public int x2;
        public int y2;

        public int x3;
        public int y3;

        public int x4;
        public int y4;

        public int color;

        public Parallelogram(int incX1, int incY1, int incX2, int incY2, 
            int incX3, int incY3, int incX4, int incY4, int incColor)
        {
            x1 = incX1;
            y1 = incY1;

            x2 = incX2;
            y2 = incY2;

            x3 = incX3;
            y3 = incY3;

            x4 = incX4;
            y4 = incY4;

            color = incColor;
        }
    }
}
