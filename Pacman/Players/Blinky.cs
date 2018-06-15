using PacMan.Abstracts;
using PacMan.Interfaces;
using System;

namespace PacMan.Players
{
    class Blinky : Ghost
    {
        public static char GetCharElement()
        {
            return 'L';
        }

        public static int GetNumberElement()
        {
            return 6;
        }
    }
}
