using PacMan;
using PacMan.Interfaces;
using PacMan.Foods;
using System;
using PacMan.Players;

namespace PacmanDemo
{
    class Program
    {
        const int SIZE = 16;
        static void Main(string[] args)
        {
            var size = new Size(32, 16);
            int[,] array = Game.LoadMap(@"C:\Users\fedyu\source\repos\pacman\PacmanDemo\map.txt", size);
            var game = new Game(array);
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
                Console.Clear();
                ShowMap(array);
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    lost=game.Move(Direction.Left);
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    lost = game.Move(Direction.Right);
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    lost = game.Move(Direction.Up);
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    lost = game.Move(Direction.Down);
                }
            }
            Console.ReadLine();
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
                            Console.Write(Empty.GetCharElement());
                            break;
                        case 1:
                            Console.Write(Wall.GetCharElement());
                            break;
                        case 2:
                            Console.Write(LittleGoal.GetCharElement());
                            break;
                        case 5:
                            Console.Write(Pacman.GetCharElement());
                            break;
                        case 7:
                            Console.Write(Clyde.GetCharElement());
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
