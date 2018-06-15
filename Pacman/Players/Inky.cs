using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan.Players
{
    public class Inky : Ghost
    {
        public static char GetCharElement()
        {
            return 'I';
        }

        public static int GetNumberElement()
        {
            return 8;
        }
    }
}
