using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan.Players
{
    public class Pinky : Ghost
    {
        public static char GetCharElement()
        {
            return 'N';
        }

        public static int GetNumberElement()
        {
            return 9;
        }
    }
}
