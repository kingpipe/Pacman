using Pacman;
using System;

namespace PacmanDemo
{
    class Program
    {
        const int SIZE = 16; 
        static void Main(string[] args)
        {
            int[,] array = Game.LoadMap(@"C:\Users\Petro Fediushko\source\repos\Pacman\PacmanDemo\map.txt", SIZE, SIZE);
            Program.Show(array);
        }
        public static void Show(int[,] array)
        {
            for(int x=0; x<SIZE; x++)
            {
                for(int y=0; y<SIZE;y++)
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
