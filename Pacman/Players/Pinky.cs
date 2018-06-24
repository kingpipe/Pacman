using PacMan.Abstracts;
using PacMan.Interfaces;
using System;

namespace PacMan.Players
{
    public class Pinky : Ghost
    {
        public override event Action SinkAboutEatPacman;

        public Pinky(Map map):base(map)
        {

        }
        public static char GetCharElement()
        {
            return 'N';
        }
    }
}
