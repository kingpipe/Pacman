using PacMan;
using PacMan.Interfaces;
using PacMan.Foods;
using System;
using PacMan.Players;

namespace PacmanDemo
{
    class DrawConsole
    {
        private object obj = new object();
        private Game Game { get; }
        public DrawConsole(Game game)
        {
            Game = game;
        }

        public void DrawMap()
        {
            Console.Clear();
            ShowMap();
            string LiveorLives = Game.Pacman.Lives == 1 ? "Live" : "Lives";
            Console.WriteLine($"{LiveorLives} {Game.Pacman.Lives} ");
            Console.WriteLine($"Score={Game.Score}");
        }

        public void TheEnd()
        {
            Console.Clear();
            Console.WriteLine("You lost");
            Console.WriteLine($"Score={Game.Pacman.Count}");
        }

        public void WriteScore(int count)
        {
            lock (obj)
            {
                Console.SetCursorPosition(6, 32);
                Console.WriteLine(count);
            }
        }

        public void EventMoving(ICoord obj)
        {
            lock (obj)
            {
                Console.SetCursorPosition(obj.Position.X, obj.Position.Y);
                Console.WriteLine(obj.GetCharElement());
            }
        }

        public bool MovePacman(Game game, Direction direction)
        {
            lock (obj)
            {
                Console.SetCursorPosition(game.Pacman.Position.X, game.Pacman.Position.Y);
                Console.WriteLine(new Empty(game.Pacman.Position).GetCharElement());

                bool value = game.Move(direction);

                Console.SetCursorPosition(game.Pacman.Position.X, game.Pacman.Position.Y);
                Console.WriteLine(game.Pacman.GetCharElement());

                return value;
            }
        }

        private void ShowMap()
        {
            ICoord[,] array = Game.Map.map;
            for (int y = 0; y < Game.Map.Height; y++)
            {
                for (int x = 0; x < Game.Map.Width; x++)
                {
                    if (array[x, y] is Empty)
                    {
                        Console.Write(new Empty(new Position(x, y)).GetCharElement());
                    }
                    if (array[x, y] is Wall)
                    {
                        Console.Write(new Wall(new Position(x, y)).GetCharElement());
                    }
                    if (array[x, y] is LittleGoal)
                    {
                        Console.Write(new LittleGoal(new Position(x, y)).GetCharElement());
                    }
                    if (array[x, y] is BigGoal)
                    {
                        Console.Write(new BigGoal(new Position(x, y)).GetCharElement());
                    }
                    if (array[x, y] is Pacman)
                    {
                        Console.Write(new Pacman().GetCharElement());
                    }
                    if (array[x, y] is Blinky)
                    {
                        Console.Write(new Blinky().GetCharElement());
                    }
                    if (array[x, y] is Clyde)
                    {
                        Console.Write(new Clyde().GetCharElement());
                    }
                    if (array[x, y] is Inky)
                    {
                        Console.Write(new Inky().GetCharElement());
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
