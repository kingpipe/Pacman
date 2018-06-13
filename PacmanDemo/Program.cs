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
            game.clyde.Start(new System.Timers.Timer(300), game.map);
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
        //public static void MovePacman(Game game, Direction direction)
        //{
        //    Console.SetCursorPosition(game.pacman.position.X, game.pacman.position.Y);
        //    Console.WriteLine(Elements.None.GetChar());
        //    game.PacmanMove(direction);
        //    Console.SetCursorPosition(game.pacman.position.X, game.pacman.position.Y);
        //    Console.WriteLine(Elements.Pacman.GetChar());

        //}
        //public static bool MoveClyde(Game game)
        //{
            
        //    Console.SetCursorPosition(game.clyde.position.X, game.clyde.position.Y);
        //    Console.WriteLine(Elements.None.GetChar());
        //    bool value=game.ClydeMove();
        //    Console.SetCursorPosition(game.clyde.position.X, game.clyde.position.Y);
        //    Console.WriteLine(Elements.Clyde.GetChar());
        //    return value;
        //}
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
                            Console.Write(Elements.LittleGoal.GetChar());
                            break;
                        case 4:
                            Console.Write(Elements.Pacman.GetChar());
                            break;
                        case 5:
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
