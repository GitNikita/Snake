using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Walls
    {
        public int Width { get; set; }
        public int Heigh { get; set; }

        public Walls(int w, int h)
        {
            Width = w;
            Heigh = h;
            HorizontalLine hl1 = new HorizontalLine(0, 0, '/', w);
            HorizontalLine hl2 = new HorizontalLine(0, h, '/', w);
            VerticalLine vl1 = new VerticalLine(0, 1, '/', h - 1);
            VerticalLine vl2 = new VerticalLine(w, 1, '/', h - 1);
            hl1.Draw();
            hl2.Draw();
            vl1.Draw();
            vl2.Draw();
        }
    }
}
