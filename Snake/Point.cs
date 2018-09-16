using System;

namespace Snake
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }

        public Point(int x, int y, char symbol)
        {
            X = x;
            Y = y;
            Symbol = symbol;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }
        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }
    }
}
