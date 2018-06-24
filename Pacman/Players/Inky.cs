using PacMan.Abstracts;
using PacMan.Interfaces;
using System;

namespace PacMan.Players
{
    public class Inky : Ghost
    {
        public override event Action SinkAboutEatPacman;

        public Inky(Map map):base(map)
        {

        }
        public static char GetCharElement()
        {
            return 'I';
        }
    }
}
