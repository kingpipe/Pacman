using PacMan.Abstracts;

namespace PacMan.Players
{
    class Inky : Ghost
    {
        public Inky(Map map, Position start) : base(map, start)
        {
            id = "inky";
            idchar = 'I';
        }
    }
}
