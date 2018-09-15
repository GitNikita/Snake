using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class FigureLine : Point
    {
        private List<Point> plist = new List<Point>();
        public int Lenght { get; set; }
        public List<Point> Plist { get => plist; set => plist = value; }

        public new void Draw()
        {
            foreach (Point p in Plist)
            {
                p.Draw();
            }
        }
        public FigureLine(int x, int y, char symbol, int lenght) : base(x, y, symbol)
        {
            Lenght = lenght;
        }

    }
}
