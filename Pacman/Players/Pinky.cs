using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan.Players
{
    public class Pinky : Ghost
    {
        public Pinky(ICoord[,] map):base(map)
        {

        }
        public static char GetCharElement()
        {
            return 'N';
        }
    }
}
