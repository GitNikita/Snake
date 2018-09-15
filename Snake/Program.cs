using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {

            HorizontalLine hline1 = new HorizontalLine(0, 0, '/', 100);
            HorizontalLine hline2 = new HorizontalLine(0, 26, '/', 100);
            VerticalLine vline1 = new VerticalLine(0, 1, '/', 24);
            VerticalLine vline2 = new VerticalLine(100, 1, '/', 24);
            hline1.Draw();
            hline2.Draw();
            vline1.Draw();
            vline2.Draw();

            Snake snake = new Snake(6, 1, 'o', 5, Direction.RIGHT);
            snake.Draw();
            snake.Move();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    snake.ChangeDirection(keyInfo);
                }
                Thread.Sleep(200);
                snake.Move();
            }
        }
    }
}
