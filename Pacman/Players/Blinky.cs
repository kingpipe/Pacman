using PacMan.Abstracts;
using PacMan.Algorithms;

namespace PacMan.Players
{
    class Blinky : Ghost
    {
        public Blinky(Position start, Map map) : base(start, map)
        {
            Id = "blinky";
            idchar = 'B';

            homePosition = new Position(Map.Widht - 4, 1);
        }

        protected override void GoToCircle() => Strategy = new GoToClockwise(); 
    }
}
