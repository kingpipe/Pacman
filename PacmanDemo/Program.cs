using PacMan;
using System;

namespace PacmanDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo key;

            var size = new Size(30, 31);
            var game = new Game(@"C:\Users\fedyu\source\repos\pacman\PacmanDemo\map.txt", size);
            var drawConsole = new DrawConsole(game);

            drawConsole.DrawMap();
            game.AddMoveHandlerToGhosts(drawConsole.EventMoving);
            game.AddMoveHandlerToPacman(drawConsole.PacmanMoving);
            game.Start();

            while (true)
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
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
                }
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    game.SetDirection(Direction.Left);
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    game.SetDirection(Direction.Right);
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    game.SetDirection(Direction.Up);
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    game.SetDirection(Direction.Down);
                }
                drawConsole.WriteScore();

                if (game.PacmanIsLive == false)
                {
                    game.Stop();
                    if (game.Lives > 0)
                    {
                        drawConsole.InformationAfterKilled();
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
                    }
                    else
                    {
                        drawConsole.TheEnd();
                        game.End();
                        break;
                    }
                }
            }
            Console.ReadLine();
        }
    }
}