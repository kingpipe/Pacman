using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan.Players
{
    public class Inky : Ghost
    {
        public Inky(ICoord[,] map):base(map)
        {

        }
        public static char GetCharElement()
        {
            return 'I';
        }
    }
}
