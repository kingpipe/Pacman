﻿namespace Pacman
{
    struct Position
    {
        public int X { get;set; }
        public int Y { get;set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public bool OnMap()
        {
            return X >= 0 && X < 16 && Y >= 0 && Y < 16;
        }
    }
}
