using PacMan.Abstracts;

namespace PacMan.Players
{
    class Pinky : Ghost
    {
        public Pinky(Map map, Position start) : base(map, start)
        {
            id = "pinky";
            idchar = 'N';
        }
    }
}
