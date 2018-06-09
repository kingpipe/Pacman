using Pacman;
using System;

namespace PacmanDemo
{
    class Program
    {
        const int SIZE = 16;
        static void Main(string[] args)
        {
            int[,] array = Game.LoadMap(@"C:\Users\Petro Fediushko\source\repos\Pacman\PacmanDemo\map.txt", 2 * SIZE, SIZE);
            Game game = new Game(7, 6, 21, 11, array);
            while (true)
            {
                bool value=true;
                if(value==false)
                {
                    Console.Clear();
                    Console.WriteLine("You lost");
                }
                Console.Clear();
                Show(array);
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    value = game.ClydeMove();
                    game.PacmanMove(Direction.Left);
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    value = game.ClydeMove();
                    game.PacmanMove(Direction.Right);
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    value = game.ClydeMove();
                    game.PacmanMove(Direction.Up);
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    value = game.ClydeMove();
                    game.PacmanMove(Direction.Down);
                }

            }
        }
        public static void Show(int[,] array)
        {
            for(int y=0; y<SIZE; y++)
            {
                for(int x=0; x<2*SIZE;x++)
                {
                    switch(array[x,y])
                    {
                        case 0:
                            Console.Write((char)183);
                            break;
                        case 1:
                            Console.Write('#');
                            break;
                        case 2:
                            Console.Write('P');
                            break;
                        case 3:
                            Console.Write('C');
                            break;
                        default:
                            break;

                    }
                }
                Console.WriteLine();
            }
        }
    }
}
