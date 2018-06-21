using PacMan.Abstracts;
using PacMan.Interfaces;
using System;

namespace PacMan.Players
{
    class Blinky : Ghost
    {
        public Blinky(ICoord[,] map):base(map)
        {

        }
        public static char GetCharElement()
        {
            return 'L';
        }
    }
}
