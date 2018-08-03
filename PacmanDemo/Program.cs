using PacMan;
using PacMan.Enums;
using System;

namespace PacmanDemo
{
    class Program
    {
        static ConsoleKeyInfo key;
        static Game game = new Game(@"C://Users//fedyu//source//repos//pacman//PacmanDemo//map.json");
        static DrawConsole drawConsole = new DrawConsole(game);

        static void Main(string[] args)
        {
            drawConsole.DrawMap();
            game.AddHandler(drawConsole.EventMoving, drawConsole.PacmanMoving, Game_PacmanIsDied, drawConsole.DrawMap);
            game.Start();

            while (true)
            {
                if (game.Lives != 0)
                {
                    key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.Enter:
                            game.Stop();
                            drawConsole.InformationAfterStop();
                            while (true)
                            {
                                key = Console.ReadKey(true);
                                if (key.Key == ConsoleKey.Spacebar)
                                {
                                    drawConsole.DrawMap();
                                    game.Start();
                                    break;
                                }
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            game.SetDirection(Direction.Left);
                            break;
                        case ConsoleKey.RightArrow:
                            game.SetDirection(Direction.Right);
                            break;
                        case ConsoleKey.UpArrow:
                            game.SetDirection(Direction.Up);
                            break;
                        case ConsoleKey.DownArrow:
                            game.SetDirection(Direction.Down);
                            break;
                    }
                }
                else
                {
                    drawConsole.TheEnd();
                    game.End();
                    break;
                }
            }
        }

        private static void Game_PacmanIsDied()
        {
            game.Stop();
            drawConsole.InformationAfterKilled();
            while (true)
            {
                if (key.Key == ConsoleKey.Spacebar)
                {
                    drawConsole.DrawMap();
                    game.Start();
                    break;
                }
            }
        }
    }
}