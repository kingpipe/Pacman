using PacMan.Abstracts;

namespace PacMan.Players
{
    class Blinky : Ghost
    {
        public Blinky(Map map, Position start) : base(map, start)
        {
            id = "blinky";
            idchar = 'B';
        }
    }
}
