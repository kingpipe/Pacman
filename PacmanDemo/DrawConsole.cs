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
            lock (obj)
            {
                Console.Clear();
                ShowMap();
                string LiveorLives = Game.Lives == 1 ? "Live" : "Lives";
                Console.WriteLine($"{LiveorLives} {Game.Lives} ");
                Console.WriteLine($"Score={Game.Score}");
            }
        }

        public void TheEnd()
        {
            lock (obj)
            {
                Console.Clear();
                Console.WriteLine("You lost");
                Console.WriteLine($"Score={Game.Score}");
            }
        }

        public void WriteScore()
        {
            lock (obj)
            {
                Console.SetCursorPosition(6, 32);
                Console.WriteLine(Game.Score);
            }
        }

        public void EventMoving(ICoord coord)
        {
            lock (obj)
            {
                Console.SetCursorPosition(coord.Position.X, coord.Position.Y);
                Console.WriteLine(coord.GetCharElement());
            }
        }

        public void PacmanMoving(ICoord coord)
        {
            lock (obj)
            {
                EventMoving(coord);
                WriteScore();
            }
        }

        public void InformationAfterStop()
        {
            lock (obj)
            {
                Console.Clear();
                string liveorlives = Game.Lives == 1 ? "live" : "lives";
                Console.WriteLine($"You have {Game.Lives} {liveorlives}");
                Console.WriteLine($"You score is {Game.Score}");
                Console.WriteLine("Press the spacebar to continue the game");
            }
        }

        public void InformationAfterKilled()
        {
            lock (obj)
            {
                Console.Clear();
                string liveorlives = Game.Lives == 1 ? "live" : "lives";
                Console.WriteLine($"You lost,you have more {Game.Lives} {liveorlives}");
                Console.WriteLine("Press the spacebar to continue the game");
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
                    if (array[x, y] is Energizer)
                    {
                        Console.Write(new Energizer(new Position(x, y)).GetCharElement());
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