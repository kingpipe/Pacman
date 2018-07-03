using PacMan;
using System;

namespace PacmanDemo
{
    class Program
    {

        static ConsoleKeyInfo key;
        static Size size = new Size(30, 31);
        static Game game = new Game(@"C:\Users\fedyu\source\repos\pacman\PacmanDemo\map.txt", size);
        static DrawConsole drawConsole = new DrawConsole(game);
        static void Main(string[] args)
        {

            drawConsole.DrawMap();
            game.AddMoveHandlerToGhosts(drawConsole.EventMoving);
            game.AddMoveHandlerToPacman(drawConsole.PacmanMoving);
            game.PacmanIsDied += Game_PacmanIsDied;
            game.Start();

            while (true)
            {
                if (game.Lives != 0)
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