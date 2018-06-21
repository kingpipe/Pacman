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
            bool lost = true;
            DrawMap(game);
            Console.WriteLine($"Score={game.pacman.Count}");
            while (true)
            {
                if (lost == false)
                {
                    game.RemovePlayers();
                    game.pacman.Lives--;
                    Console.Clear();
                    if (game.pacman.Lives != 0)
                    {

                        string liveorlives = game.pacman.Lives == 1 ? "live" : "lives";
                        Console.WriteLine($"You lost,you have more {game.pacman.Lives} {liveorlives}");
                        Console.WriteLine("Press the spacebar to continue the game");
                        while (true)
                        {
                            ConsoleKeyInfo space = Console.ReadKey(true);
                            if (space.Key == ConsoleKey.Spacebar)
                            {
                                DrawMap(game);
                                Console.WriteLine($"Score={game.pacman.Count}");
                                break;
                            }
                        }
                        game.Start();
                        CreateElements(game);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You lost");
                        Console.WriteLine($"Score={game.pacman.Count}");
                        break;
                    }
                }
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    lost = Move(game, Direction.Left);
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    lost = Move(game, Direction.Right);
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    lost = Move(game, Direction.Up);
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    lost = Move(game, Direction.Down);
                }
                WriteScore(game.pacman.Count);
            }
            Console.ReadLine();
        }

        private static void WriteScore(int count)
        {
            Console.SetCursorPosition(6,32);
            Console.WriteLine(count);
        }

        private static void DrawMap(Game game)
        {
            Console.Clear();
            ShowMap(game.map);
            string LiveorLives = game.pacman.Lives == 1 ? "Live" : "Lives";
            Console.WriteLine($"{LiveorLives} {game.pacman.Lives} ");
        }

        public static bool Move(Game game, Direction direction)
        {
            RemoveElements(game);
            bool value = game.Move(direction);
            CreateElements(game);
            return value;

        }

        private static void CreateElements(Game game)
        {
            Console.SetCursorPosition(game.pacman.position.X, game.pacman.position.Y);
            Console.WriteLine(Pacman.GetCharElement());

            Console.SetCursorPosition(game.clyde.position.X, game.clyde.position.Y);
            Console.WriteLine(Clyde.GetCharElement());
        }

        private static void RemoveElements(Game game)
        {
            Console.SetCursorPosition(game.pacman.position.X, game.pacman.position.Y);
            Console.WriteLine(Empty.GetCharElement());
            Console.SetCursorPosition(game.clyde.position.X, game.clyde.position.Y);
            Console.WriteLine(Empty.GetCharElement());
        }

        public static void ShowMap(IMap map)
        {
            ICoord[,] array = map.map;
            for(int y=0; y<map.Height; y++)
            {
                for(int x=0; x<map.Width;x++)
                {
                    if(array[x,y] is Empty)
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
