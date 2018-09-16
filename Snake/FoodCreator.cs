using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class FoodCreator
    {
        Point f;
        public Point F { get => f; set => f = value; }

        public FoodCreator()
        {
            Random r = new Random();
            F = new Point(r.Next(1, 99), r.Next(1, 23), '?');
            F.Draw();
        }

        
    }
}
