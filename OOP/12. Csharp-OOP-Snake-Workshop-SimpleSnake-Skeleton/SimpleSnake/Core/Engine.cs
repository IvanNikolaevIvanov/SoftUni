
namespace SimpleSnake.Core
{
using Contracts;
    using System;

    using Enums;
    using GameObjects;
    using System.Threading;
    using System.Diagnostics;

    public class Engine : IEngine
    {
        private const double DefaultSleepTime = 100;
        private const double EasyDifficultyStep = 0.01;
        private const double MediumDifficultyStep = 0.03;
        private const double HardDifficultyStep = 0.05;

        private readonly Stopwatch timer;

        private readonly Point[] directionPoints;
        private Direction direction;
        private Snake snake;
        private readonly Wall wall;
        private double sleepTime;
        private double dificultyStep;

        private Engine()
        {
            this.directionPoints = new Point[4];
            this.sleepTime= DefaultSleepTime;
            this.timer = new Stopwatch();
        }

        public Engine(Wall wall) 
            : this()
        {
            this.wall = wall;
        }

        public void Run()
        {
            this.GetDirectionPoints();
            this.SetDifficultyLevel();

            while (true)
            {
                this.timer.Start();
                this.ShowScore();

                if (Console.KeyAvailable)
                {
                    this.GetNextDirection();
                }

                bool canMove = snake.CanMove(this.directionPoints[(int)this.direction]);

                if (!canMove) 
                {
                    this.AskUSerForRestart();
                }

                this.sleepTime -= this.dificultyStep;
                Thread.Sleep((int)this.sleepTime);
            }

        }

        private void ShowScore()
        {
            Console.SetCursorPosition(this.wall.LeftX + 1, 0);
            Console.Write($"Score: {this.snake.FoodEaten}");
            Console.SetCursorPosition(this.wall.LeftX + 1, 1);
            Console.Write($"Game duration: {this.timer.ElapsedMilliseconds / 1_000_000:d2}:{this.timer.ElapsedMilliseconds / 1000:d2}");
            Console.CursorVisible = false;
        }

        private void SetDifficultyLevel()
        {
            Console.SetCursorPosition(this.wall.LeftX + 1, 3);
            Console.Write("Choose game difficulty: ");
            Console.SetCursorPosition(this.wall.LeftX + 1, 4);
            Console.Write("1: Easy");
            Console.SetCursorPosition(this.wall.LeftX + 1, 5);
            Console.Write("2: Medium");
            Console.SetCursorPosition(this.wall.LeftX + 1, 6);
            Console.Write("3: Hard");
            Console.SetCursorPosition(this.wall.LeftX + 1, 7);

            string answer = Console.ReadLine();

            if (answer == "1")
            {
                this.dificultyStep = EasyDifficultyStep;
            }
            else if (answer == "2")
            {
                this.dificultyStep = MediumDifficultyStep;

            }
            else if (answer == "3")
            {
                this.dificultyStep = HardDifficultyStep;

            }
            else
            {
                StartUp.Main();
            }
            Console.Clear();
            this.wall.InitializeBorders();
            this.snake = new Snake(this.wall);
        }

        private void GetDirectionPoints()
        {
            this.directionPoints[(int)Direction.Right] = new Point(1, 0);
            this.directionPoints[(int)Direction.Left] = new Point(-1, 0);
            this.directionPoints[(int)Direction.Down] = new Point(0, 1);
            this.directionPoints[(int)Direction.Up] = new Point(0, -1);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow || userInput.Key == ConsoleKey.A)
            {
                if (this.direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow || userInput.Key == ConsoleKey.D)
            {
                if (this.direction != Direction.Left)
                {
                    this.direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow || userInput.Key == ConsoleKey.W)
            {
                if (this.direction != Direction.Down)
                {
                    this.direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow || userInput.Key == ConsoleKey.S)
            {
                if (this.direction != Direction.Up)
                {
                    this.direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }

        private void AskUSerForRestart()
        {
            int leftX = this.wall.LeftX + 1;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n ");
            
            string answer = Console.ReadLine();

            if (answer.ToLower() == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                this.StopGame();
            }

        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game Over!");
            Environment.Exit(0);

        }


    }
}
