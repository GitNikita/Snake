using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : FigureLine
    {
        Direction d;
        private Point head;

        public Snake(int xhead, int yhead, char symbol, int lenght, Direction d) : base(xhead, yhead, symbol, lenght)
        {
            Head = new Point(xhead, yhead, symbol);
            D = d;
            switch (D)
            {
                case Direction.UP:
                    for (int i = 0; i <= lenght; i++)
                    {
                        Plist.Add(new Point(xhead, yhead++, symbol));
                    }
                    break;
                case Direction.LEFT:
                    for (int i = 0; i <= lenght; i++)
                    {
                        Plist.Add(new Point(xhead++, yhead, symbol));
                    }
                    break;
                case Direction.RIGHT:
                    for (int i = 0; i <= lenght; i++)
                    {
                        Plist.Add(new Point(xhead--, yhead, symbol));
                    }
                    break;
                case Direction.DOWN:
                    for (int i = 0; i <= lenght; i++)
                    {
                        Plist.Add(new Point(xhead, yhead--, symbol));
                    }
                    break;
            }
        }

        public Point Head { get => head; set => head = value; }
        internal Direction D { get => d; set => d = value; }
        public void Move()
        {
            Point last = Plist.Last();
            Point head = new Point(Plist.First().X, Plist.First().Y, Plist.First().Symbol);
            switch (D)
            {
                case Direction.UP:
                    Plist.Insert(1, head);
                    --Plist.First().Y;
                    Plist.First().Draw();
                    break;
                case Direction.LEFT:
                    Plist.Insert(1, head);
                    --Plist.First().X;
                    Plist.First().Draw();
                    break;
                case Direction.RIGHT:
                    Plist.Insert(1, head);
                    ++Plist.First().X;
                    Plist.First().Draw();
                    break;
                case Direction.DOWN:
                    Plist.Insert(1, head);
                    ++Plist.First().Y;
                    Plist.First().Draw();
                    break;
            }
            Plist.Last().Clear();
            Plist.Remove(last);
        }

        public void ChangeDirection(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    if(D != Direction.LEFT && D != Direction.RIGHT)
                    {
                        D = Direction.LEFT;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (D != Direction.RIGHT && D != Direction.LEFT)
                    {
                        D = Direction.RIGHT;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (D != Direction.UP && D != Direction.DOWN)
                    {
                        D = Direction.UP;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (D != Direction.DOWN && D != Direction.UP)
                    {
                        D = Direction.DOWN;
                    }
                    break;
            }

        }
    }
}

