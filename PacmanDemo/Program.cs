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
            Game game = new Game(7, 6, array);
            while (true)
            {
                Console.Clear();
                Show(array);
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    game.Move();
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
                        default:
                            break;

                    }
                }
                Console.WriteLine();
            }
        }
    }
}
