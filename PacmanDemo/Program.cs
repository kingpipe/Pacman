using PacMan;
using PacMan.Interfaces;
using PacMan.Foods;
using System;
using PacMan.Players;
using System.Threading;

namespace PacmanDemo
{
    class Program
    {
        static object obj = new object();
        static void Main(string[] args)
        {   
            var size = new Size(30, 31);
            var game = new Game(@"C:\Users\fedyu\source\repos\pacman\PacmanDemo\map.txt", size);
            DrawMap(game);
            game.Ghosts.AddMoveHandler(EventMoving);

            Console.CursorVisible = false;
            Console.WriteLine($"Score={game.Score}");
            game.Start();
            while (true)
            {
                if (game.PacmanIsLive == false)
                {
                    game.PacmanIsDied();
                    Console.Clear();
                    if (game.Lives > 0)
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

        private static void EventMoving(ICoord obj)
        {
            lock (obj)
            {
                Console.SetCursorPosition(obj.Position.X, obj.Position.Y);
                Console.WriteLine(obj.GetCharElement());
            }
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
                MovePacman(game, Direction.Left);
            }
            if (key.Key == ConsoleKey.RightArrow)
            {
                MovePacman(game, Direction.Right);
            }
            if (key.Key == ConsoleKey.UpArrow)
            {
                MovePacman(game, Direction.Up);
            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                MovePacman(game, Direction.Down);
            }
            WriteScore(game.Pacman.Count);
         }

        private static void WriteScore(int count)
        {
            lock (obj)
            {
                Console.SetCursorPosition(6, 32);
                Console.WriteLine(count);
            }
        }

        private static void DrawMap(Game game)
        {
            Console.Clear();
            ShowMap(game.Map);
            string LiveorLives = game.Pacman.Lives == 1 ? "Live" : "Lives";
            Console.WriteLine($"{LiveorLives} {game.Pacman.Lives} ");
        }

        private static bool MovePacman(Game game, Direction direction)
        {
            Console.SetCursorPosition(game.Pacman.Position.X, game.Pacman.Position.Y);
            Console.WriteLine(new Empty(game.Pacman.Position).GetCharElement());

            bool value = game.Move(direction);

            Console.SetCursorPosition(game.Pacman.Position.X, game.Pacman.Position.Y);
            Console.WriteLine(game.Pacman.GetCharElement());

            return value;

        }

        private static void CreateElements(Game game)
        {
            Console.SetCursorPosition(game.Pacman.Position.X, game.Pacman.Position.Y);
            Console.WriteLine(game.Pacman.GetCharElement());

            Console.SetCursorPosition(game.Ghosts.Blinky.Position.X, game.Ghosts.Blinky.Position.Y);
            Console.WriteLine(game.Ghosts.Blinky.GetCharElement());

            Console.SetCursorPosition(game.Ghosts.Clyde.Position.X, game.Ghosts.Clyde.Position.Y);
            Console.WriteLine(game.Ghosts.Clyde.GetCharElement());

            Console.SetCursorPosition(game.Ghosts.Inky.Position.X, game.Ghosts.Inky.Position.Y);
            Console.WriteLine(game.Ghosts.Inky.GetCharElement());
        }


        private static void ShowMap(Map map)
        {
            ICoord[,] array = map.map;
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
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
                        Console.Write(new Pacman(map).GetCharElement());
                    }
                    if (array[x, y] is Blinky)
                    {
                        Console.Write(new Blinky(map).GetCharElement());
                    }
                    if (array[x, y] is Clyde)
                    {
                        Console.Write(new Clyde(map).GetCharElement());
                    }
                    if (array[x, y] is Inky)
                    {
                        Console.Write(new Inky(map).GetCharElement());
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
