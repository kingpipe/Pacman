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
            Console.CursorVisible = false;

            var size = new Size(30, 31);
            var game = new Game(@"C:\Users\fedyu\source\repos\pacman\PacmanDemo\map.txt", size);
            var drawConsole = new DrawConsole(game);

            drawConsole.DrawMap();
            game.Ghosts.AddMoveHandler(drawConsole.EventMoving);
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
                                drawConsole.DrawMap();
                                break;
                            }
                        }
                        game.Start();
                    }
                    else
                    {
                        drawConsole.TheEnd();
                        game.End();
                        break;
                    }
                }
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    drawConsole.MovePacman(game, Direction.Left);
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    drawConsole.MovePacman(game, Direction.Right);
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    drawConsole.MovePacman(game, Direction.Up);
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    drawConsole.MovePacman(game, Direction.Down);
                }
                drawConsole.WriteScore(game.Pacman.Count);
            }
            Console.ReadLine();
        }
    }
}
