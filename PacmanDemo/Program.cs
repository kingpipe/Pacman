using Pacman;
using System;

namespace PacmanDemo
{
    class Program
    {
        const int SIZE = 16;
        static void Main(string[] args)
        {
            int[,] array = Game.LoadMap(@"C:\Users\fedyu\source\repos\pacman\PacmanDemo\map.txt", 2 * SIZE, SIZE);
            Game game = new Game(array);
            bool lost = true;
            Console.Clear();
            ShowMap(array);
            while (true)
            {
                if (lost==false)
                {
                    Console.Clear();
                    Console.WriteLine("You lost");
                    break;
                }
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    MovePacman(game, Direction.Left);
                    lost = MoveClyde(game);
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    MovePacman(game, Direction.Right);
                    lost = MoveClyde(game);
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    MovePacman(game, Direction.Up);
                    lost = MoveClyde(game);
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    MovePacman(game, Direction.Down);
                    lost = MoveClyde(game);
                }
            }
            Console.ReadLine();
        }
        public static void MovePacman(Game game, Direction direction)
        {
            Console.SetCursorPosition(game.pacman.position.X, game.pacman.position.Y);
            Console.WriteLine(Elements.None.GetChar());
            game.PacmanMove(direction);
            Console.SetCursorPosition(game.pacman.position.X, game.pacman.position.Y);
            Console.WriteLine(Elements.Pacman.GetChar());

        }
        public static bool MoveClyde(Game game)
        {
            
            Console.SetCursorPosition(game.clyde.position.X, game.clyde.position.Y);
            Console.WriteLine(Elements.None.GetChar());
            bool value=game.ClydeMove();
            Console.SetCursorPosition(game.clyde.position.X, game.clyde.position.Y);
            Console.WriteLine(Elements.Clyde.GetChar());
            return value;
        }
        public static void ShowMap(int[,] array)
        {
            for(int y=0; y<SIZE; y++)
            {
                for(int x=0; x<2*SIZE;x++)
                {
                    switch(array[x,y])
                    {
                        case 0:
                            Console.Write(Elements.None.GetChar());
                            break;
                        case 1:
                            Console.Write(Elements.Wall.GetChar());
                            break;
                        case 2:
                            Console.Write(Elements.Pacman.GetChar());
                            break;
                        case 3:
                            Console.Write(Elements.Clyde.GetChar());
                            break;
                        default:
                            Console.Write(' ');
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
