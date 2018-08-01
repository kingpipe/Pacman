using PacMan.Abstracts;

namespace PacMan.Players
{
    class Clyde : Ghost
    {
        public Clyde(Map map, Position start) : base(map, start)
        {
            id = "clyde";
            idchar = 'C';
        }
    }
}
