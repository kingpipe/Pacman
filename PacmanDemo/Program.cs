using PacMan;
using PacMan.Interfaces;
using PacMan.Foods;
using System;
using PacMan.Players;

namespace PacmanDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = new Size(30, 31);
            var game = new Game(@"C:\Users\fedyu\source\repos\pacman\PacmanDemo\map.txt", size);
            DrawMap(game);
            Console.CursorVisible = false;
            Console.WriteLine($"Score={game.Score}");
            game.Start();
            while (true)
            {
                if (game.PacmanIsLive == false)
                {
                    game.PacmanIsDied();
                    Console.Clear();
                    if (game.Lives != 0)
                    {
                        string liveorlives = game.Lives == 1 ? "live" : "lives";
                        Console.WriteLine($"You lost,you have more {game.Lives} {liveorlives}");
                        Console.WriteLine("Press the spacebar to continue the game");
                        while (true)
                        {
                            ConsoleKeyInfo space = Console.ReadKey(true);
                            if (space.Key == ConsoleKey.Spacebar)
                            {
                                DrawMap(game);
                                Console.WriteLine($"Score={game.Score}");
                                break;
                            }
                        }
                        game.Start();
                        CreateElements(game);
                    }
                    else
                    {
                        TheEnd(game);
                        game.End();
                        break;
                    }
                }
                ChoiceDirectionMovePacman(game);
            }
            Console.ReadLine();
        }
        private static void TheEnd(Game game)
        {
            Console.Clear();
            Console.WriteLine("You lost");
            Console.WriteLine($"Score={game.Pacman.Count}");
        }

        private static void ChoiceDirectionMovePacman(Game game)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.LeftArrow)
            {
                Move(game, Direction.Left);
            }
            if (key.Key == ConsoleKey.RightArrow)
            {
                Move(game, Direction.Right);
            }
            if (key.Key == ConsoleKey.UpArrow)
            {
                Move(game, Direction.Up);
            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                Move(game, Direction.Down);
            }
            WriteScore(game.Pacman.Count);
        }

        private static void WriteScore(int count)
        {
            Console.SetCursorPosition(6, 32);
            Console.WriteLine(count);
        }

        private static void DrawMap(Game game)
        {
            Console.Clear();
            ShowMap(game.Map);
            string LiveorLives = game.Pacman.Lives == 1 ? "Live" : "Lives";
            Console.WriteLine($"{LiveorLives} {game.Pacman.Lives} ");
        }

        private static bool Move(Game game, Direction direction)
        {
            RemoveElements(game);
            bool value = game.Move(direction);
            CreateElements(game);
            return value;

        }

        private static void CreateElements(Game game)
        {
            Console.SetCursorPosition(game.Pacman.Position.X, game.Pacman.Position.Y);
            Console.WriteLine(Pacman.GetCharElement());

            Console.SetCursorPosition(game.Clyde.Position.X, game.Clyde.Position.Y);
            Console.WriteLine(Blinky.GetCharElement());
        }

        private static void RemoveElements(Game game)
        {
            Console.SetCursorPosition(game.Pacman.Position.X, game.Pacman.Position.Y);
            Console.WriteLine(Empty.GetCharElement());
            Console.SetCursorPosition(game.Clyde.Position.X, game.Clyde.Position.Y);
            Console.WriteLine(Empty.GetCharElement());
        }

        private static void ShowMap(IMap map)
        {
            ICoord[,] array = map.map;
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    if (array[x, y] is Empty)
                    {
                        Console.Write(Empty.GetCharElement());
                    }
                    if (array[x, y] is Wall)
                    {
                        Console.Write(Wall.GetCharElement());
                    }
                    if (array[x, y] is LittleGoal)
                    {
                        Console.Write(LittleGoal.GetCharElement());
                    }
                    if (array[x, y] is BigGoal)
                    {
                        Console.Write(BigGoal.GetCharElement());
                    }
                    if (array[x, y] is Pacman)
                    {
                        Console.Write(Pacman.GetCharElement());
                    }
                    if (array[x, y] is Blinky)
                    {
                        Console.Write(Blinky.GetCharElement());
                    }
                    if (array[x, y] is Clyde)
                    {
                        Console.Write(Clyde.GetCharElement());
                    }

                }
                Console.WriteLine();
            }
        }
    }
}
