using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Счет: 0";
            Console.SetWindowSize(101, 27);
            Walls w = new Walls(100, 26);
            Snake snake = new Snake(10, 10, 'o', 7, Direction.RIGHT);
            snake.Draw();
            snake.Move();

            var fc = new FoodCreator();
            while (true)
            {
                if (snake.CrashedIntoItself() || snake.CrashedIntoTheWall(w))
                {
                    break;
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    snake.ChangeDirection(keyInfo);
                }
                if (snake.NextStepWithFood(fc.F))
                {
                    snake.Eat(fc.F);
                    fc = new FoodCreator();
                }

                Thread.Sleep(100);
                snake.Move();
            }
        }
    }
}
