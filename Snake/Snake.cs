using System;
using System.Linq;

namespace Snake
{
    class Snake : FigureLine
    {
        public Direction D { get; set; }

        public Snake(int xhead, int yhead, char symbol, int lenght, Direction d) : base(xhead, yhead, symbol, lenght)
        {
            D = d;
            switch (D)
            {
                case Direction.UP:
                    for (int i = 0; i < lenght; i++)
                    {
                        Plist.Add(new Point(xhead, yhead++, symbol));
                    }
                    break;
                case Direction.LEFT:
                    for (int i = 0; i < lenght; i++)
                    {
                        Plist.Add(new Point(xhead++, yhead, symbol));
                    }
                    break;
                case Direction.RIGHT:
                    for (int i = 0; i < lenght; i++)
                    {
                        Plist.Add(new Point(xhead--, yhead, symbol));
                    }
                    break;
                case Direction.DOWN:
                    for (int i = 0; i < lenght; i++)
                    {
                        Plist.Add(new Point(xhead, yhead--, symbol));
                    }
                    break;
            }
        }

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
                    if (D != Direction.LEFT && D != Direction.RIGHT)
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
        public void Eat(Point p)
        {
            Plist.Insert(0, new Point(p.X, p.Y, 'o'));
            Plist.First().Draw();
            Lenght++;
            Console.Title = $"Счет: {Lenght}";

        }
        public bool NextStepWithFood(Point p)
        {
            switch (D)
            {
                case Direction.UP:
                    if (Plist.First().X == p.X && Plist.First().Y - 1 == p.Y)
                    {
                        return true;
                    }
                    break;
                case Direction.LEFT:
                    if (Plist.First().X - 1 == p.X && Plist.First().Y == p.Y)
                    {
                        return true;
                    }
                    break;
                case Direction.RIGHT:
                    if (Plist.First().X + 1 == p.X && Plist.First().Y == p.Y)
                    {
                        return true;
                    }
                    break;
                case Direction.DOWN:
                    if (Plist.First().X == p.X && Plist.First().Y + 1 == p.Y)
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }
        public bool CrashedIntoItself()
        {
            Point head = Plist.First();
            for(int i = 1; i < Lenght; i++)
            {
                if(Plist[i].X == head.X && Plist[i].Y == head.Y)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CrashedIntoTheWall(Walls w)
        {
            Point head = Plist.First();
            if(head.X == 0 || head.X == w.Width || head.Y == w.Heigh || head.Y == 0)
            {
                return true;
            }
            return false;
        }
    }
}

