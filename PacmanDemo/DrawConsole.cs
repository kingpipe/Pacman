﻿using PacMan;
using PacMan.Interfaces;
using System;

namespace PacmanDemo
{
    class DrawConsole
    {
        private readonly object obj = new object();
        private Game Game { get; }

        public DrawConsole(Game game)
        {
            Console.CursorVisible = false;
            Game = game;
        }

        public void DrawMap()
        {
            lock (obj)
            {
                Console.Clear();
                ShowMap();
                string LiveorLives = Game.Lives == 1 ? "Live" : "Lives";
                Console.WriteLine($"{LiveorLives} {Game.Lives} ");
                Console.WriteLine($"Score={Game.Score}");
                Console.WriteLine($"Level={Game.Level}");
            }
        }

        public void TheEnd()
        {
            lock (obj)
            {
                Console.Clear();
                Console.WriteLine("You lost");
                Console.WriteLine($"Score={Game.Score}");
                Console.ReadKey();
            }
        }

        public void WriteScore()
        {
            lock (obj)
            {
                Console.SetCursorPosition(6, 32);
                Console.WriteLine(Game.Score);
            }
        }

        public void EventMoving(ICoord coord)
        {
            lock (obj)
            {
                Console.SetCursorPosition(coord.Position.X, coord.Position.Y);
                Console.WriteLine(coord.GetCharElement());
            }
        }

        public void PacmanMoving(ICoord coord)
        {
            lock (obj)
            {
                EventMoving(coord);
                WriteScore();
            }
        }

        public void InformationAfterStop()
        {
            lock (obj)
            {
                Console.Clear();
                string liveorlives = Game.Lives == 1 ? "live" : "lives";
                Console.WriteLine($"You have {Game.Lives} {liveorlives}");
                Console.WriteLine($"You score is {Game.Score}");
                Console.WriteLine("Press the spacebar to continue the game");
            }
        }

        public void InformationAfterKilled()
        {
            lock (obj)
            {
                Console.Clear();
                string liveorlives = Game.Lives == 1 ? "live" : "lives";
                Console.WriteLine($"You lost,you have more {Game.Lives} {liveorlives}");
                Console.WriteLine("Press the spacebar to continue the game");
            }
        }

        private void ShowMap()
        {
            ICoord[,] array = Game.Map.map;
            for (int y = 0; y < Game.Map.Height; y++)
            {
                for (int x = 0; x < Game.Map.Width; x++)
                {
                    Console.Write(array[x, y].GetCharElement());
                }
                Console.WriteLine();
            }
        }
    }
}